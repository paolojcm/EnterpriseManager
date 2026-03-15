using DatabaseUtilities.General.Services;
using EnterpriseManager.Domain.General.Objects;
using EnterpriseManager.Domain.Specific.State.Entities;
using EnterpriseManager.Domain.Specific.State.Repositories;
using EnterpriseManager.Infrastructure.Specific.State.Mappers;
using EnterpriseManager.Infrastructure.Specific.State.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EnterpriseManager.Persistence.Specific.State.Repositories
{
	public class StateInfrSpecRepo : IStateDomaSpecRepo
	{
		private readonly ILogger<StateInfrSpecRepo> _iLogger;

		private IDatabaseUtilitiesSpecServ _iDatabaseUtilitiesSpecServ;

		public StateInfrSpecRepo(
			ILogger<StateInfrSpecRepo> iLogger,
			IDatabaseUtilitiesSpecServ iDatabaseUtilitiesSpecServ
		)
		{
			_iLogger = iLogger;
			_iDatabaseUtilitiesSpecServ = iDatabaseUtilitiesSpecServ;
		}

		public async Task<StateDomaSpecEnti> GetStateByIdAsync(long id)
		{
			StateDomaSpecEnti? stateDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					stat1.*
				FROM
					State stat1
				WHERE
					stat1.id = @id
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@id", id);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [StatePersSpecRepo] -> {{method}}: [GetTheStateByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@id]: ({id})");

			try
			{
				StateInfrSpecMode stateInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectAsync<StateInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);

				stateDomaSpecEnti = StateInfrSpecMapp.MapToDomainEntity(stateInfrSpecMode);
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

			return stateDomaSpecEnti;
		}

		public async Task<IEnumerable<StateDomaSpecEnti>> GetStatesByAcronymOrName(string? acronymOrName)
		{
			List<StateDomaSpecEnti>? statesDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					stat1.*
				FROM
					State stat1
				WHERE
					(
							(UPPER(stat1.Acronym) like UPPER('%' || @acronym || '%'))
						or
							(UPPER(stat1.Name) like UPPER('%' || @name || '%'))
					)
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@acronym", $"{acronymOrName}");
			parametersWithTheirValues.Add("@name", $"{acronymOrName}");

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [StatePersSpecRepo] -> {{method}}: [GetStateByNameAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@acronym]: ({acronymOrName})");
			_iLogger.LogDebug($"{guid} | [@name]: ({acronymOrName})");

			try
			{
				IEnumerable<StateInfrSpecMode> statesInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectsAsync<StateInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);
				if ((statesInfrSpecMode != null) && (statesInfrSpecMode.Count() > 0))
				{
					statesDomaSpecEnti = new List<StateDomaSpecEnti>();
					StateDomaSpecEnti? stateDomaSpecEnti = null;
					foreach (StateInfrSpecMode stateInfrSpecMode in statesInfrSpecMode)
					{
						stateDomaSpecEnti = StateInfrSpecMapp.MapToDomainEntity(stateInfrSpecMode);
						statesDomaSpecEnti.Add(stateDomaSpecEnti);
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

			return statesDomaSpecEnti;
		}

		private async Task<bool> InsertStateAsync(StateDomaSpecEnti stateDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				INSERT INTO
					State (Acronym, Name, CountryId)
				VALUES 
					(@acronym, @name, @countryId)
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [StatePersSpecRepo] -> {{method}}: [InsertStateAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				StateInfrSpecMode stateInfrSpecMode = StateInfrSpecMapp.MapToPersistenceModel(stateDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [acronym]: ({stateInfrSpecMode.Acronym})");
				_iLogger.LogDebug($"{guid} | [name]: ({stateInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [countryId]: ({stateInfrSpecMode.CountryId})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@acronym", stateInfrSpecMode.Acronym);
				parametersWithTheirValues.Add("@name", stateInfrSpecMode.Name);
				parametersWithTheirValues.Add("@countryId", stateInfrSpecMode.CountryId);

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

		private async Task<bool> UpdateStateAsync(StateDomaSpecEnti stateDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				UPDATE 
					State 
				SET
					Acronym = @acronym,
					Name = @name,
					CountryId = @countryId
				WHERE
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [StatePersSpecRepo] -> {{method}}: [UpdateStateAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				StateInfrSpecMode stateInfrSpecMode = StateInfrSpecMapp.MapToPersistenceModel(stateDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [acronym]: ({stateInfrSpecMode.Acronym})");
				_iLogger.LogDebug($"{guid} | [name]: ({stateInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [stateId]: ({stateInfrSpecMode.CountryId})");
				_iLogger.LogDebug($"{guid} | [id]: ({stateInfrSpecMode.Id})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@acronym", stateInfrSpecMode.Acronym);
				parametersWithTheirValues.Add("@name", stateInfrSpecMode.Name);
				parametersWithTheirValues.Add("@countryId", stateInfrSpecMode.CountryId);
				parametersWithTheirValues.Add("@id", stateInfrSpecMode.Id);

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

		public async Task<bool> InsertOrUpdateStateAsync(StateDomaSpecEnti stateDomaSpecEnti)
		{
			bool output = false;

			if (stateDomaSpecEnti.Id == 0)
			{
				output = await InsertStateAsync(stateDomaSpecEnti);
			}
			else
			{
				output = await UpdateStateAsync(stateDomaSpecEnti);
			}

			return output;
		}

		public async Task<bool> DeleteStateByIdAsync(long id)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				DELETE 
				FROM
					State
				WHERE 
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [StatePersSpecRepo] -> {{method}}: [DeleteStateByIdAsync]");
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