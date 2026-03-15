using DatabaseUtilities.General.Services;
using EnterpriseManager.Domain.General.Objects;
using EnterpriseManager.Domain.Specific.City.Entities;
using EnterpriseManager.Domain.Specific.City.Repositories;
using EnterpriseManager.Infrastructure.Specific.City.Mappers;
using EnterpriseManager.Infrastructure.Specific.City.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EnterpriseManager.Persistence.Specific.City.Repositories
{
	public class CityInfrSpecRepo : ICityDomaSpecRepo
	{
		private readonly ILogger<CityInfrSpecRepo> _iLogger;

		private IDatabaseUtilitiesSpecServ _iDatabaseUtilitiesSpecServ;

		public CityInfrSpecRepo(
			ILogger<CityInfrSpecRepo> iLogger,
			IDatabaseUtilitiesSpecServ iDatabaseUtilitiesSpecServ
		)
		{
			_iLogger = iLogger;
			_iDatabaseUtilitiesSpecServ = iDatabaseUtilitiesSpecServ;
		}

		public async Task<CityDomaSpecEnti> GetCityByIdAsync(long id)
		{
			CityDomaSpecEnti? cityDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					city1.*
				FROM
					City city1
				WHERE
					city1.id = @id
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@id", id);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CityPersSpecRepo] -> {{method}}: [GetTheCityByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@id]: ({id})");

			try
			{
				CityInfrSpecMode cityInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectAsync<CityInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);

				cityDomaSpecEnti = CityInfrSpecMapp.MapToDomainEntity(cityInfrSpecMode);
			}
			catch (InfrastructureLayerException)
			{
				throw;
			}
			catch (Exception exception)
			{
				_iLogger.LogError($"{guid} | [Exception]: ({exception})");
				throw new InfrastructureLayerException(HttpStatusCode.InternalServerError, exception.Message);
			}

			return cityDomaSpecEnti;
		}

		public async Task<IEnumerable<CityDomaSpecEnti>> GetCitiesByNameAsync(string? name)
		{
			List<CityDomaSpecEnti>? citiesDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					city1.*
				FROM
					City city1
				WHERE
					UPPER(city1.Name) like UPPER('%' || @name || '%')
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@name", name);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CityPersSpecRepo] -> {{method}}: [GetCityByNameAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@name]: ({name})");

			try
			{
				IEnumerable<CityInfrSpecMode> citiesInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectsAsync<CityInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);
				if ((citiesInfrSpecMode != null) && (citiesInfrSpecMode.Count() > 0))
				{
					citiesDomaSpecEnti = new List<CityDomaSpecEnti>();
					CityDomaSpecEnti? cityDomaSpecEnti = null;
					foreach (CityInfrSpecMode cityInfrSpecMode in citiesInfrSpecMode)
					{
						cityDomaSpecEnti = CityInfrSpecMapp.MapToDomainEntity(cityInfrSpecMode);
						citiesDomaSpecEnti.Add(cityDomaSpecEnti);
					}
				}
			}
			catch (InfrastructureLayerException)
			{
				throw;
			}
			catch (Exception exception)
			{
				_iLogger.LogError($"{guid} | [Exception]: ({exception})");
				throw new InfrastructureLayerException(HttpStatusCode.InternalServerError, exception.Message);
			}

			return citiesDomaSpecEnti;
		}

		private async Task<bool> InsertCityAsync(CityDomaSpecEnti cityDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				INSERT INTO
					City (Name, StateId)
				VALUES 
					(@name, @stateId)
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CityPersSpecRepo] -> {{method}}: [InsertCityAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				CityInfrSpecMode cityInfrSpecMode = CityInfrSpecMapp.MapToPersistenceModel(cityDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({cityInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [stateId]: ({cityInfrSpecMode.StateId})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", cityInfrSpecMode.Name);
				parametersWithTheirValues.Add("@stateId", cityInfrSpecMode.StateId);

				await _iDatabaseUtilitiesSpecServ.ExecuteNonQueryAsync(sqliteTransaction, sqlStatement, parametersWithTheirValues);

				sqliteTransaction.Commit();

				output = true;
			}
			catch (InfrastructureLayerException)
			{
				throw;
			}
			catch (Exception exception)
			{
				_iLogger.LogError($"{guid} | [Exception]: ({exception})");
				if (sqliteTransaction != null)
				{
					sqliteTransaction.Rollback();
				}
				throw new InfrastructureLayerException(HttpStatusCode.InternalServerError, exception.Message);
			}

			return output;
		}

		private async Task<bool> UpdateCityAsync(CityDomaSpecEnti cityDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				UPDATE 
					City 
				SET
					Name = @name,
					StateId = @stateId
				WHERE
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CityPersSpecRepo] -> {{method}}: [UpdateCityAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				CityInfrSpecMode cityInfrSpecMode = CityInfrSpecMapp.MapToPersistenceModel(cityDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({cityInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [stateId]: ({cityInfrSpecMode.StateId})");
				_iLogger.LogDebug($"{guid} | [id]: ({cityInfrSpecMode.Id})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", cityInfrSpecMode.Name);
				parametersWithTheirValues.Add("@stateId", cityInfrSpecMode.StateId);
				parametersWithTheirValues.Add("@id", cityInfrSpecMode.Id);

				await _iDatabaseUtilitiesSpecServ.ExecuteNonQueryAsync(sqliteTransaction, sqlStatement, parametersWithTheirValues);

				sqliteTransaction.Commit();

				output = true;
			}
			catch (InfrastructureLayerException)
			{
				throw;
			}
			catch (Exception exception)
			{
				_iLogger.LogError($"{guid} | [Exception]: ({exception})");
				if (sqliteTransaction != null)
				{
					sqliteTransaction.Rollback();
				}
				throw new InfrastructureLayerException(HttpStatusCode.InternalServerError, exception.Message);
			}

			return output;
		}

		public async Task<bool> InsertOrUpdateCityAsync(CityDomaSpecEnti cityDomaSpecEnti)
		{
			bool output = false;

			if (cityDomaSpecEnti.Id == 0)
			{
				output = await InsertCityAsync(cityDomaSpecEnti);
			}
			else
			{
				output = await UpdateCityAsync(cityDomaSpecEnti);
			}

			return output;
		}

		public async Task<bool> DeleteCityByIdAsync(long id)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				DELETE 
				FROM
					City
				WHERE 
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CityPersSpecRepo] -> {{method}}: [DeleteCityByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				_iLogger.LogDebug($"{guid} | [id]: ({id})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@id", id);

				await _iDatabaseUtilitiesSpecServ.ExecuteNonQueryAsync(sqliteTransaction, sqlStatement, parametersWithTheirValues);

				sqliteTransaction.Commit();

				output = true;
			}
			catch (InfrastructureLayerException)
			{
				throw;
			}
			catch (Exception exception)
			{
				_iLogger.LogError($"{guid} | [Exception]: ({exception})");
				if (sqliteTransaction != null)
				{
					sqliteTransaction.Rollback();
				}
				throw new InfrastructureLayerException(HttpStatusCode.InternalServerError, exception.Message);
			}

			return output;
		}
	}
}