using DatabaseUtilities.General.Services;
using EnterpriseManager.Domain.General.Objects;
using EnterpriseManager.Domain.Specific.OperatingSegment.Entities;
using EnterpriseManager.Domain.Specific.OperatingSegment.Repositories;
using EnterpriseManager.Infrastructure.Specific.OperatingSegment.Mappers;
using EnterpriseManager.Infrastructure.Specific.OperatingSegment.Models;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Mappers;
using EnterpriseManager.Infrastructure.Specific.MeanOfContact.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EnterpriseManager.Persistence.Specific.OperatingSegment.Repositories
{
	public class OperatingSegmentInfrSpecRepo : IOperatingSegmentDomaSpecRepo
	{
		private readonly ILogger<OperatingSegmentInfrSpecRepo> _iLogger;

		private IDatabaseUtilitiesSpecServ _iDatabaseUtilitiesSpecServ;

		public OperatingSegmentInfrSpecRepo(
			ILogger<OperatingSegmentInfrSpecRepo> iLogger,
			IDatabaseUtilitiesSpecServ iDatabaseUtilitiesSpecServ
		)
		{
			_iLogger = iLogger;
			_iDatabaseUtilitiesSpecServ = iDatabaseUtilitiesSpecServ;
		}

		public async Task<OperatingSegmentDomaSpecEnti> GetOperatingSegmentByIdAsync(long id)
		{
			OperatingSegmentDomaSpecEnti? operatingSegmentDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					oper1Segm1.*
				FROM
					Operating_Segment oper1Segm1
				WHERE
					oper1Segm1.id = @id
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@id", id);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [OperatingSegmentPersSpecRepo] -> {{method}}: [GetTheOperatingSegmentByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@id]: ({id})");

			try
			{
				OperatingSegmentInfrSpecMode operatingSegmentInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectAsync<OperatingSegmentInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);

				operatingSegmentDomaSpecEnti = OperatingSegmentInfrSpecMapp.MapToDomainEntity(operatingSegmentInfrSpecMode);
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

			return operatingSegmentDomaSpecEnti;
		}

		public async Task<IEnumerable<OperatingSegmentDomaSpecEnti>> GetOperatingSegmentsByNameAsync(string? name)
		{
			List<OperatingSegmentDomaSpecEnti>? operatingSegmentsDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					oper1Segm1.*
				FROM
					Operating_Segment oper1Segm1
				WHERE
					UPPER(oper1Segm1.Name) like UPPER('%' || @name || '%')
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@name", name);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [OperatingSegmentPersSpecRepo] -> {{method}}: [GetOperatingSegmentByNameAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@name]: ({name})");

			try
			{
				IEnumerable<OperatingSegmentInfrSpecMode> operatingSegmentsInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectsAsync<OperatingSegmentInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);
				if ((operatingSegmentsInfrSpecMode != null) && (operatingSegmentsInfrSpecMode.Count() > 0))
				{
					operatingSegmentsDomaSpecEnti = new List<OperatingSegmentDomaSpecEnti>();
					OperatingSegmentDomaSpecEnti? operatingSegmentDomaSpecEnti = null;
					foreach (OperatingSegmentInfrSpecMode operatingSegmentInfrSpecMode in operatingSegmentsInfrSpecMode)
					{
						operatingSegmentDomaSpecEnti = OperatingSegmentInfrSpecMapp.MapToDomainEntity(operatingSegmentInfrSpecMode);
						operatingSegmentsDomaSpecEnti.Add(operatingSegmentDomaSpecEnti);
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

			return operatingSegmentsDomaSpecEnti;
		}

		private async Task<bool> InsertOperatingSegmentAsync(OperatingSegmentDomaSpecEnti operatingSegmentDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				INSERT INTO
					Operating_Segment (Name)
				VALUES 
					(@name)
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [OperatingSegmentPersSpecRepo] -> {{method}}: [InsertOperatingSegmentAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				OperatingSegmentInfrSpecMode operatingSegmentInfrSpecMode = OperatingSegmentInfrSpecMapp.MapToPersistenceModel(operatingSegmentDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({operatingSegmentInfrSpecMode.Name})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", operatingSegmentInfrSpecMode.Name);

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

		private async Task<bool> UpdateOperatingSegmentAsync(OperatingSegmentDomaSpecEnti operatingSegmentDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				UPDATE 
					Operating_Segment 
				SET
					Name = @name
				WHERE
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [OperatingSegmentPersSpecRepo] -> {{method}}: [UpdateOperatingSegmentAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				OperatingSegmentInfrSpecMode operatingSegmentInfrSpecMode = OperatingSegmentInfrSpecMapp.MapToPersistenceModel(operatingSegmentDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({operatingSegmentInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [id]: ({operatingSegmentInfrSpecMode.Id})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", operatingSegmentInfrSpecMode.Name);
				parametersWithTheirValues.Add("@id", operatingSegmentInfrSpecMode.Id);

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

		public async Task<bool> InsertOrUpdateOperatingSegmentAsync(OperatingSegmentDomaSpecEnti operatingSegmentDomaSpecEnti)
		{
			bool output = false;

			if (operatingSegmentDomaSpecEnti.Id == 0)
			{
				output = await InsertOperatingSegmentAsync(operatingSegmentDomaSpecEnti);
			}
			else
			{
				output = await UpdateOperatingSegmentAsync(operatingSegmentDomaSpecEnti);
			}

			return output;
		}

		public async Task<bool> DeleteOperatingSegmentByIdAsync(long id)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				DELETE 
				FROM
					Operating_Segment
				WHERE 
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [OperatingSegmentPersSpecRepo] -> {{method}}: [DeleteOperatingSegmentByIdAsync]");
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