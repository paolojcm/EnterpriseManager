using DatabaseUtilities.General.Services;
using EnterpriseManager.Domain.General.Objects;
using EnterpriseManager.Domain.Specific.MeanOfContact.Entities;
using EnterpriseManager.Domain.Specific.MeanOfContact.Repositories;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Mappers;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EnterpriseManager.Infrastructure.Specific.MeanOfContact.Repositories
{
	public class MeanOfContactInfrSpecRepo : IMeanOfContactDomaSpecRepo
	{
		private readonly ILogger<MeanOfContactInfrSpecRepo> _iLogger;

		private IDatabaseUtilitiesSpecServ _iDatabaseUtilitiesSpecServ;

		public MeanOfContactInfrSpecRepo(
			ILogger<MeanOfContactInfrSpecRepo> iLogger,
			IDatabaseUtilitiesSpecServ iDatabaseUtilitiesSpecServ
		)
		{
			_iLogger = iLogger;
			_iDatabaseUtilitiesSpecServ = iDatabaseUtilitiesSpecServ;
		}

		public async Task<MeanOfContactDomaSpecEnti> GetMeanOfContactByIdAsync(long id)
		{
			MeanOfContactDomaSpecEnti? meanOfContactDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					mean1Of1Cont1.*
				FROM
					Mean_Of_Contact mean1Of1Cont1
				WHERE
					mean1Of1Cont1.id = @id
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@id", id);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [MeanOfContactPersSpecRepo] -> {{method}}: [GetTheMeanOfContactByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@id]: ({id})");

			try
			{
				MeanOfContactInfrSpecMode meanOfContactInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectAsync<MeanOfContactInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);

				meanOfContactDomaSpecEnti = MeanOfContactInfrSpecMapp.MapToDomainEntity(meanOfContactInfrSpecMode);
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

			return meanOfContactDomaSpecEnti;
		}

		public async Task<IEnumerable<MeanOfContactDomaSpecEnti>> GetMeansOfContactByNameAsync(string? name)
		{
			List<MeanOfContactDomaSpecEnti>? meansOfContactDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					mean1Of1Cont1.*
				FROM
					Mean_Of_Contact mean1Of1Cont1
				WHERE
					UPPER(mean1Of1Cont1.Name) like UPPER('%' || @name || '%')
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@name", name);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [MeanOfContactPersSpecRepo] -> {{method}}: [GetMeanOfContactByNameAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@name]: ({name})");

			try
			{
				IEnumerable<MeanOfContactInfrSpecMode> meansOfContactInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectsAsync<MeanOfContactInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);
				if (meansOfContactInfrSpecMode != null && meansOfContactInfrSpecMode.Count() > 0)
				{
					meansOfContactDomaSpecEnti = new List<MeanOfContactDomaSpecEnti>();
					MeanOfContactDomaSpecEnti? meanOfContactDomaSpecEnti = null;
					foreach (MeanOfContactInfrSpecMode meanOfContactInfrSpecMode in meansOfContactInfrSpecMode)
					{
						meanOfContactDomaSpecEnti = MeanOfContactInfrSpecMapp.MapToDomainEntity(meanOfContactInfrSpecMode);
						meansOfContactDomaSpecEnti.Add(meanOfContactDomaSpecEnti);
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

			return meansOfContactDomaSpecEnti;
		}

		private async Task<bool> InsertMeanOfContactAsync(MeanOfContactDomaSpecEnti meanOfContactDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				INSERT INTO
					Mean_Of_Contact (Name)
				VALUES 
					(@name)
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [MeanOfContactPersSpecRepo] -> {{method}}: [InsertMeanOfContactAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				MeanOfContactInfrSpecMode meanOfContactInfrSpecMode = MeanOfContactInfrSpecMapp.MapToPersistenceModel(meanOfContactDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({meanOfContactInfrSpecMode.Name})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", meanOfContactInfrSpecMode.Name);

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

		private async Task<bool> UpdateMeanOfContactAsync(MeanOfContactDomaSpecEnti meanOfContactDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				UPDATE 
					Mean_Of_Contact 
				SET
					Name = @name
				WHERE
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [MeanOfContactPersSpecRepo] -> {{method}}: [UpdateMeanOfContactAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				MeanOfContactInfrSpecMode meanOfContactInfrSpecMode = MeanOfContactInfrSpecMapp.MapToPersistenceModel(meanOfContactDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({meanOfContactInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [id]: ({meanOfContactInfrSpecMode.Id})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", meanOfContactInfrSpecMode.Name);
				parametersWithTheirValues.Add("@id", meanOfContactInfrSpecMode.Id);

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

		public async Task<bool> InsertOrUpdateMeanOfContactAsync(MeanOfContactDomaSpecEnti meanOfContactDomaSpecEnti)
		{
			bool output = false;

			if (meanOfContactDomaSpecEnti.Id == 0)
			{
				output = await InsertMeanOfContactAsync(meanOfContactDomaSpecEnti);
			}
			else
			{
				output = await UpdateMeanOfContactAsync(meanOfContactDomaSpecEnti);
			}

			return output;
		}

		public async Task<bool> DeleteMeanOfContactByIdAsync(long id)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				DELETE 
				FROM
					Mean_Of_Contact
				WHERE 
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [MeanOfContactPersSpecRepo] -> {{method}}: [DeleteMeanOfContactByIdAsync]");
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