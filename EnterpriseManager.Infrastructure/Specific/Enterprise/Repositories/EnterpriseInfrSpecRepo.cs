using DatabaseUtilities.General.Services;
using EnterpriseManager.Domain.General.Objects;
using EnterpriseManager.Domain.Specific.Enterprise.Entities;
using EnterpriseManager.Domain.Specific.Enterprise.Repositories;
using EnterpriseManager.Infrastructure.Specific.Enterprise.Mappers;
using EnterpriseManager.Infrastructure.Specific.Enterprise.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EnterpriseManager.Persistence.Specific.Enterprise.Repositories
{
	public class EnterpriseInfrSpecRepo : IEnterpriseDomaSpecRepo
	{
		private readonly ILogger<EnterpriseInfrSpecRepo> _iLogger;

		private IDatabaseUtilitiesSpecServ _iDatabaseUtilitiesSpecServ;

		public EnterpriseInfrSpecRepo(
			ILogger<EnterpriseInfrSpecRepo> iLogger,
			IDatabaseUtilitiesSpecServ iDatabaseUtilitiesSpecServ
		)
		{
			_iLogger = iLogger;
			_iDatabaseUtilitiesSpecServ = iDatabaseUtilitiesSpecServ;
		}

		public async Task<EnterpriseDomaSpecEnti> GetEnterpriseByIdAsync(long id)
		{
			EnterpriseDomaSpecEnti? enterpriseDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					ente1.*
				FROM
					Enterprise ente1
				WHERE
					ente1.id = @id
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@id", id);

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterprisePersSpecRepo] -> {{method}}: [GetTheEnterpriseByIdAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@id]: ({id})");

			try
			{
				EnterpriseInfrSpecMode enterpriseInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectAsync<EnterpriseInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);

				enterpriseDomaSpecEnti = EnterpriseInfrSpecMapp.MapToDomainEntity(enterpriseInfrSpecMode);
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

			return enterpriseDomaSpecEnti;
		}

		public async Task<IEnumerable<EnterpriseDomaSpecEnti>> GetEnterprisesByNameAsync(string? name)
		{
			List<EnterpriseDomaSpecEnti>? enterprisesDomaSpecEnti = null;

			string sqlStatement = @"
				SELECT
					ente1.*
				FROM
					Enterprise ente1
				WHERE
					UPPER(ente1.Name) like UPPER('%' || @name || '%')
			";

			Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
			parametersWithTheirValues.Add("@name", $"{name}");

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterprisePersSpecRepo] -> {{method}}: [GetEnterpriseByNameAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");
			_iLogger.LogDebug($"{guid} | [@name]: ({name})");

			try
			{
				IEnumerable<EnterpriseInfrSpecMode> enterprisesInfrSpecMode = await _iDatabaseUtilitiesSpecServ.GetObjectsAsync<EnterpriseInfrSpecMode>(null, sqlStatement, parametersWithTheirValues);
				if ((enterprisesInfrSpecMode != null) && (enterprisesInfrSpecMode.Count() > 0))
				{
					enterprisesDomaSpecEnti = new List<EnterpriseDomaSpecEnti>();
					EnterpriseDomaSpecEnti? enterpriseDomaSpecEnti = null;
					foreach (EnterpriseInfrSpecMode enterpriseInfrSpecMode in enterprisesInfrSpecMode)
					{
						enterpriseDomaSpecEnti = EnterpriseInfrSpecMapp.MapToDomainEntity(enterpriseInfrSpecMode);
						enterprisesDomaSpecEnti.Add(enterpriseDomaSpecEnti);
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

			return enterprisesDomaSpecEnti;
		}

		private async Task<bool> InsertEnterpriseAsync(EnterpriseDomaSpecEnti enterpriseDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				INSERT INTO
					Enterprise (Name, Status, Entrepreneur_Id, Operating_Segment_Id, City_Id)
				VALUES 
					(@name, @status, @entrepreneurId, @operatingSegmentId, @cityId)
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterprisePersSpecRepo] -> {{method}}: [InsertEnterpriseAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				EnterpriseInfrSpecMode enterpriseInfrSpecMode = EnterpriseInfrSpecMapp.MapToPersistenceModel(enterpriseDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({enterpriseInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [status]: ({enterpriseInfrSpecMode.Status})");
				_iLogger.LogDebug($"{guid} | [entrepreneurId]: ({enterpriseInfrSpecMode.EntrepreneurId})");
				_iLogger.LogDebug($"{guid} | [operatingSegmentId]: ({enterpriseInfrSpecMode.OperatingSegmentId})");
				_iLogger.LogDebug($"{guid} | [cityId]: ({enterpriseInfrSpecMode.CityId})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", enterpriseInfrSpecMode.Name);
				parametersWithTheirValues.Add("@status", enterpriseInfrSpecMode.Status);
				parametersWithTheirValues.Add("@entrepreneurId", enterpriseInfrSpecMode.EntrepreneurId);
				parametersWithTheirValues.Add("@operatingSegmentId", enterpriseInfrSpecMode.OperatingSegmentId);
				parametersWithTheirValues.Add("@cityId", enterpriseInfrSpecMode.CityId);

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

		private async Task<bool> UpdateEnterpriseAsync(EnterpriseDomaSpecEnti enterpriseDomaSpecEnti)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				UPDATE 
					Enterprise 
				SET
					Name = @name,
					Status = @status,
					Entrepreneur_Id = @entrepreneurId,
					Operating_Segment_Id = @operatingSegmentId,
					City_Id = @cityId
				WHERE
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterprisePersSpecRepo] -> {{method}}: [UpdateEnterpriseAsync]");
			_iLogger.LogDebug($"{guid} | [query]: ({sqlStatement})");

			try
			{
				sqliteTransaction = (SqliteTransaction)_iDatabaseUtilitiesSpecServ.GetConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

				EnterpriseInfrSpecMode enterpriseInfrSpecMode = EnterpriseInfrSpecMapp.MapToPersistenceModel(enterpriseDomaSpecEnti);
				_iLogger.LogDebug($"{guid} | [name]: ({enterpriseInfrSpecMode.Name})");
				_iLogger.LogDebug($"{guid} | [status]: ({enterpriseInfrSpecMode.Status})");
				_iLogger.LogDebug($"{guid} | [entrepreneurId]: ({enterpriseInfrSpecMode.EntrepreneurId})");
				_iLogger.LogDebug($"{guid} | [operatingSegmentId]: ({enterpriseInfrSpecMode.OperatingSegmentId})");
				_iLogger.LogDebug($"{guid} | [cityId]: ({enterpriseInfrSpecMode.CityId})");
				_iLogger.LogDebug($"{guid} | [id]: ({enterpriseInfrSpecMode.Id})");

				Dictionary<string, object> parametersWithTheirValues = new Dictionary<string, object>();
				parametersWithTheirValues.Add("@name", enterpriseInfrSpecMode.Name);
				parametersWithTheirValues.Add("@status", enterpriseInfrSpecMode.Status);
				parametersWithTheirValues.Add("@entrepreneurId", enterpriseInfrSpecMode.EntrepreneurId);
				parametersWithTheirValues.Add("@operatingSegmentId", enterpriseInfrSpecMode.OperatingSegmentId);
				parametersWithTheirValues.Add("@cityId", enterpriseInfrSpecMode.CityId);
				parametersWithTheirValues.Add("@id", enterpriseInfrSpecMode.Id);

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

		public async Task<bool> InsertOrUpdateEnterpriseAsync(EnterpriseDomaSpecEnti enterpriseDomaSpecEnti)
		{
			bool output = false;

			if (enterpriseDomaSpecEnti.Id == 0)
			{
				output = await InsertEnterpriseAsync(enterpriseDomaSpecEnti);
			}
			else
			{
				output = await UpdateEnterpriseAsync(enterpriseDomaSpecEnti);
			}

			return output;
		}

		public async Task<bool> DeleteEnterpriseByIdAsync(long id)
		{
			bool output = false;

			SqliteTransaction? sqliteTransaction = null;

			string sqlStatement = @"
				DELETE 
				FROM
					Enterprise
				WHERE 
					Id = @id
			";

			Guid guid = Guid.NewGuid();
			_iLogger.LogDebug($"{guid} | {{class}}: [EnterprisePersSpecRepo] -> {{method}}: [DeleteEnterpriseByIdAsync]");
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