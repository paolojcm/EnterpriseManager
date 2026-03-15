using DatabaseUtilities.General.Services;
using EnterpriseManager.Domain.General.Objects;
using EnterpriseManager.Domain.Specific.EnterpriseContact.Entities;
using EnterpriseManager.Domain.Specific.EnterpriseContact.Repositories;
using EnterpriseManager.Infrastructure.Specific.EnterpriseContact.Mappers;
using EnterpriseManager.Infrastructure.Specific.EnterpriseContact.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EnterpriseManager.Persistence.Specific.EnterpriseContact.Repositories
{
	public class EnterpriseContactInfrSpecRepo : IEnterpriseContactDomaSpecRepo
	{
		private readonly ILogger<EnterpriseContactInfrSpecRepo> _iLogger;

		private IDatabaseUtilitiesSpecServ _iDatabaseUtilitiesSpecServ;

		public EnterpriseContactInfrSpecRepo(
			ILogger<EnterpriseContactInfrSpecRepo> iLogger,
			IDatabaseUtilitiesSpecServ iDatabaseUtilitiesSpecServ
		)
		{
			_iLogger = iLogger;
			_iDatabaseUtilitiesSpecServ = iDatabaseUtilitiesSpecServ;
		}

		public async Task<EnterpriseContactDomaSpecEnti> GetEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId)
		{
			EnterpriseContactDomaSpecEnti? enterpriseContactDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					ente1Cont1.*
				FROM
					Enterprise_Contact ente1Cont1
				WHERE
					ente1Cont1.Mean_Of_Contact_Id = @meanOfContactId
				AND
					ente1Cont1.Enterprise_Id = @enterpriseId
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterpriseContactPersSpecRepo] -> {{method}}: [GetTheEnterpriseContactByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@meanOfContactId]: ({meanOfContactId})");
			_iLogger.LogDebug($"{guid} | [@enterpriseId]: ({enterpriseId})");

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@meanOfContactId", meanOfContactId);
			parametersWithTheirValues.Add("@enterpriseId", enterpriseId);

			try
			{
				EnterpriseContactInfrSpecMode enterpriseContactInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectAsync<EnterpriseContactInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);

				enterpriseContactDomaSpecEnti = EnterpriseContactInfrSpecMapp.MapToDomainEntity(enterpriseContactInfrSpecMode);
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

			return enterpriseContactDomaSpecEnti;
		}

		public async Task<IEnumerable<EnterpriseContactDomaSpecEnti>> GetEnterpriseContactsByEnterpriseIdAsync(long enterpriseId)
		{
			List<EnterpriseContactDomaSpecEnti>? enterpriseContactsDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					ente1Cont1.*
				FROM
					Enterprise_Contact ente1Cont1
				WHERE
					ente1Cont1.Enterprise_Id = @enterpriseId
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterpriseContactPersSpecRepo] -> {{method}}: [GetEnterpriseContactByNameAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@enterpriseId]: ({enterpriseId})");

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@enterpriseId", enterpriseId);

			try
			{
				IEnumerable<EnterpriseContactInfrSpecMode> enterpriseContactsInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectsAsync<EnterpriseContactInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);
				if ((enterpriseContactsInfrSpecMode != null) && (enterpriseContactsInfrSpecMode.Count() > 0))
				{
					enterpriseContactsDomaSpecEnti = new List<EnterpriseContactDomaSpecEnti>();
					EnterpriseContactDomaSpecEnti? enterpriseContactDomaSpecEnti = null;
					foreach (EnterpriseContactInfrSpecMode enterpriseContactInfrSpecMode in enterpriseContactsInfrSpecMode)
					{
						enterpriseContactDomaSpecEnti = EnterpriseContactInfrSpecMapp.MapToDomainEntity(enterpriseContactInfrSpecMode);
						enterpriseContactsDomaSpecEnti.Add(enterpriseContactDomaSpecEnti);
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

			return enterpriseContactsDomaSpecEnti;
		}

		public async Task<bool> InsertEnterpriseContactAsync(EnterpriseContactDomaSpecEnti enterpriseContactDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				INSERT INTO
					Enterprise_Contact (Mean_Of_Contact_Id, Enterprise_Id, Contents)
				VALUES 
					(@meanOfContactId, @enterpriseId, @contents)
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterpriseContactPersSpecRepo] -> {{method}}: [InsertEnterpriseContactAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				EnterpriseContactInfrSpecMode enterpriseContactInfrSpecMode = EnterpriseContactInfrSpecMapp.MapToPersistenceModel(enterpriseContactDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [meanOfContactId]: ({enterpriseContactInfrSpecMode.MeanOfContactId})");
				_iLogger.LogDebug($"{guid} | [enterpriseId]: ({enterpriseContactInfrSpecMode.EnterpriseId})");
				_iLogger.LogDebug($"{guid} | [contents]: ({enterpriseContactInfrSpecMode.Contents})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@meanOfContactId", enterpriseContactInfrSpecMode.MeanOfContactId);
				parametersWithTheirValues.Add("@enterpriseId", enterpriseContactInfrSpecMode.EnterpriseId);
				parametersWithTheirValues.Add("@contents", $"{enterpriseContactInfrSpecMode.Contents}");

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

		public async Task<bool> UpdateEnterpriseContactAsync(EnterpriseContactDomaSpecEnti enterpriseContactDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				UPDATE 
					Enterprise_Contact 
				SET
					contents = @contents
				WHERE
					Mean_Of_Contact_Id = @meanOfContactId
				AND
					Enterprise_Id = @enterpriseId
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterpriseContactPersSpecRepo] -> {{method}}: [UpdateEnterpriseContactAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				EnterpriseContactInfrSpecMode enterpriseContactInfrSpecMode = EnterpriseContactInfrSpecMapp.MapToPersistenceModel(enterpriseContactDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [meanOfContactId]: ({enterpriseContactInfrSpecMode.MeanOfContactId})");
				_iLogger.LogDebug($"{guid} | [enterpriseId]: ({enterpriseContactInfrSpecMode.EnterpriseId})");
				_iLogger.LogDebug($"{guid} | [contents]: ({enterpriseContactInfrSpecMode.Contents})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@meanOfContactId", enterpriseContactInfrSpecMode.MeanOfContactId);
				parametersWithTheirValues.Add("@enterpriseId", enterpriseContactInfrSpecMode.EnterpriseId);
				parametersWithTheirValues.Add("@contents", $"{enterpriseContactInfrSpecMode.Contents}");

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

		public async Task<bool> DeleteEnterpriseContactByMeanOfContactIdAndEnterpriseIdAsync(long meanOfContactId, long enterpriseId)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				DELETE 
				FROM
					Enterprise_Contact
				WHERE
					Mean_Of_Contact_Id = @meanOfContactId
				AND
					Enterprise_Id = @enterpriseId
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterpriseContactPersSpecRepo] -> {{method}}: [DeleteEnterpriseContactByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				_iLogger.LogDebug($"{guid} | [meanOfContactId]: ({meanOfContactId})");
				_iLogger.LogDebug($"{guid} | [enterpriseId]: ({enterpriseId})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@meanOfContactId", meanOfContactId);
				parametersWithTheirValues.Add("@enterpriseId", enterpriseId);

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