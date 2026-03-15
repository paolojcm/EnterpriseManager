using DatabaseUtilities.General.Services;
using EnterpriseManager.Domain.General.Objects;
using EnterpriseManager.Domain.Specific.Entrepreneur.Entities;
using EnterpriseManager.Domain.Specific.Entrepreneur.Repositories;
using EnterpriseManager.Infrastructure.Specific.Entrepreneur.Mappers;
using EnterpriseManager.Infrastructure.Specific.Entrepreneur.Models;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Mappers;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EnterpriseManager.Persistence.Specific.Entrepreneur.Repositories
{
	public class EntrepreneurInfrSpecRepo : IEntrepreneurDomaSpecRepo
	{
		private readonly ILogger<EntrepreneurInfrSpecRepo> _iLogger;

		private IDatabaseUtilitiesSpecServ _iDatabaseUtilitiesSpecServ;

		public EntrepreneurInfrSpecRepo(
			ILogger<EntrepreneurInfrSpecRepo> iLogger,
			IDatabaseUtilitiesSpecServ iDatabaseUtilitiesSpecServ
		)
		{
			_iLogger = iLogger;
			_iDatabaseUtilitiesSpecServ = iDatabaseUtilitiesSpecServ;
		}

		public async Task<EntrepreneurDomaSpecEnti> GetEntrepreneurByIdAsync(long id)
		{
			EntrepreneurDomaSpecEnti? entrepreneurDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					oper1Segm1.*
				FROM
					Entrepreneur oper1Segm1
				WHERE
					oper1Segm1.id = @id
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@id", id);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EntrepreneurPersSpecRepo] -> {{method}}: [GetTheEntrepreneurByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@id]: ({id})");

			try
			{
				EntrepreneurInfrSpecMode entrepreneurInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectAsync<EntrepreneurInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);

				entrepreneurDomaSpecEnti = EntrepreneurInfrSpecMapp.MapToDomainEntity(entrepreneurInfrSpecMode);
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

			return entrepreneurDomaSpecEnti;
		}

		public async Task<IEnumerable<EntrepreneurDomaSpecEnti>> GetEntrepreneursByNameAsync(string? name)
		{
			List<EntrepreneurDomaSpecEnti>? entrepreneursDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					oper1Segm1.*
				FROM
					Entrepreneur oper1Segm1
				WHERE
					UPPER(oper1Segm1.Name) like UPPER('%' || @name || '%')
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@name", name);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EntrepreneurPersSpecRepo] -> {{method}}: [GetEntrepreneurByNameAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@name]: ({name})");

			try
			{
				IEnumerable<EntrepreneurInfrSpecMode> entrepreneursInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectsAsync<EntrepreneurInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);
				if ((entrepreneursInfrSpecMode != null) && (entrepreneursInfrSpecMode.Count() > 0))
				{
					entrepreneursDomaSpecEnti = new List<EntrepreneurDomaSpecEnti>();
					EntrepreneurDomaSpecEnti? entrepreneurDomaSpecEnti = null;
					foreach (EntrepreneurInfrSpecMode entrepreneurInfrSpecMode in entrepreneursInfrSpecMode)
					{
						entrepreneurDomaSpecEnti = EntrepreneurInfrSpecMapp.MapToDomainEntity(entrepreneurInfrSpecMode);
						entrepreneursDomaSpecEnti.Add(entrepreneurDomaSpecEnti);
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

			return entrepreneursDomaSpecEnti;
		}

		private async Task<bool> InsertEntrepreneurAsync(EntrepreneurDomaSpecEnti entrepreneurDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				INSERT INTO
					Entrepreneur (Name)
				VALUES 
					(@name)
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EntrepreneurPersSpecRepo] -> {{method}}: [InsertEntrepreneurAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				EntrepreneurInfrSpecMode entrepreneurInfrSpecMode = EntrepreneurInfrSpecMapp.MapToPersistenceModel(entrepreneurDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({entrepreneurInfrSpecMode.Name})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", entrepreneurInfrSpecMode.Name);

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

		private async Task<bool> UpdateEntrepreneurAsync(EntrepreneurDomaSpecEnti entrepreneurDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				UPDATE 
					Entrepreneur 
				SET
					Name = @name
				WHERE
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EntrepreneurPersSpecRepo] -> {{method}}: [UpdateEntrepreneurAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				EntrepreneurInfrSpecMode entrepreneurInfrSpecMode = EntrepreneurInfrSpecMapp.MapToPersistenceModel(entrepreneurDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({entrepreneurInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [id]: ({entrepreneurInfrSpecMode.Id})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", entrepreneurInfrSpecMode.Name);
				parametersWithTheirValues.Add("@id", entrepreneurInfrSpecMode.Id);

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

		public async Task<bool> InsertOrUpdateEntrepreneurAsync(EntrepreneurDomaSpecEnti entrepreneurDomaSpecEnti)
		{
			bool output = false;

			if (entrepreneurDomaSpecEnti.Id == 0)
			{
				output = await InsertEntrepreneurAsync(entrepreneurDomaSpecEnti);
			}
			else
			{
				output = await UpdateEntrepreneurAsync(entrepreneurDomaSpecEnti);
			}

			return output;
		}

		public async Task<bool> DeleteEntrepreneurByIdAsync(long id)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				DELETE 
				FROM
					Entrepreneur
				WHERE 
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EntrepreneurPersSpecRepo] -> {{method}}: [DeleteEntrepreneurByIdAsync]");
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