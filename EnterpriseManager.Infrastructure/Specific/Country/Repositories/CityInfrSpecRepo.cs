using DatabaseUtilities.General.Services;
using EnterpriseManager.Domain.General.Objects;
using EnterpriseManager.Domain.Specific.Country.Entities;
using EnterpriseManager.Domain.Specific.Country.Repositories;
using EnterpriseManager.Infrastructure.Specific.Country.Mappers;
using EnterpriseManager.Infrastructure.Specific.Country.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EnterpriseManager.Persistence.Specific.Country.Repositories
{
	public class CountryInfrSpecRepo : ICountryDomaSpecRepo
	{
		private readonly ILogger<CountryInfrSpecRepo> _iLogger;

		private IDatabaseUtilitiesSpecServ _iDatabaseUtilitiesSpecServ;

		public CountryInfrSpecRepo(
			ILogger<CountryInfrSpecRepo> iLogger,
			IDatabaseUtilitiesSpecServ iDatabaseUtilitiesSpecServ
		)
		{
			_iLogger = iLogger;
			_iDatabaseUtilitiesSpecServ = iDatabaseUtilitiesSpecServ;
		}

		public async Task<CountryDomaSpecEnti> GetCountryByIdAsync(long id)
		{
			CountryDomaSpecEnti? countryDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					country1.*
				FROM
					Country country1
				WHERE
					country1.id = @id
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@id", id);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CountryPersSpecRepo] -> {{method}}: [GetTheCountryByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@id]: ({id})");

			try
			{
				CountryInfrSpecMode countryInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectAsync<CountryInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);

				countryDomaSpecEnti = CountryInfrSpecMapp.MapToDomainEntity(countryInfrSpecMode);
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

			return countryDomaSpecEnti;
		}

		public async Task<IEnumerable<CountryDomaSpecEnti>> GetCountriesByNameAsync(string? name)
		{
			List<CountryDomaSpecEnti>? countriesDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					country1.*
				FROM
					Country country1
				WHERE
					UPPER(country1.Name) like UPPER('%' || @name || '%')
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@name", name);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CountryPersSpecRepo] -> {{method}}: [GetCountryByNameAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@name]: ({name})");

			try
			{
				IEnumerable<CountryInfrSpecMode> countriesInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectsAsync<CountryInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);
				if ((countriesInfrSpecMode != null) && (countriesInfrSpecMode.Count() > 0))
				{
					countriesDomaSpecEnti = new List<CountryDomaSpecEnti>();
					CountryDomaSpecEnti? countryDomaSpecEnti = null;
					foreach (CountryInfrSpecMode countryInfrSpecMode in countriesInfrSpecMode)
					{
						countryDomaSpecEnti = CountryInfrSpecMapp.MapToDomainEntity(countryInfrSpecMode);
						countriesDomaSpecEnti.Add(countryDomaSpecEnti);
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

			return countriesDomaSpecEnti;
		}

		private async Task<bool> InsertCountryAsync(CountryDomaSpecEnti countryDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				INSERT INTO
					Country (Name)
				VALUES 
					(@name)
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CountryPersSpecRepo] -> {{method}}: [InsertCountryAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				CountryInfrSpecMode countryInfrSpecMode = CountryInfrSpecMapp.MapToPersistenceModel(countryDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({countryInfrSpecMode.Name})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", countryInfrSpecMode.Name);

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

		private async Task<bool> UpdateCountryAsync(CountryDomaSpecEnti countryDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				UPDATE 
					Country 
				SET
					Name = @name
				WHERE
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CountryPersSpecRepo] -> {{method}}: [UpdateCountryAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				CountryInfrSpecMode countryInfrSpecMode = CountryInfrSpecMapp.MapToPersistenceModel(countryDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({countryInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [id]: ({countryInfrSpecMode.Id})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", countryInfrSpecMode.Name);
				parametersWithTheirValues.Add("@id", countryInfrSpecMode.Id);

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

		public async Task<bool> InsertOrUpdateCountryAsync(CountryDomaSpecEnti countryDomaSpecEnti)
		{
			bool output = false;

			if (countryDomaSpecEnti.Id == 0)
			{
				output = await InsertCountryAsync(countryDomaSpecEnti);
			}
			else
			{
				output = await UpdateCountryAsync(countryDomaSpecEnti);
			}

			return output;
		}

		public async Task<bool> DeleteCountryByIdAsync(long id)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				DELETE 
				FROM
					Country
				WHERE 
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [CountryPersSpecRepo] -> {{method}}: [DeleteCountryByIdAsync]");
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