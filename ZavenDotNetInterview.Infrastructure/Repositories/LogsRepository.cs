using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Core.Repositories;
using ZavenDotNetInterview.Persistence.Config;

namespace ZavenDotNetInterview.Infrastructure.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly IDbConnection _db;

        public LogsRepository(DatabaseConfig config)
        {
            _db = new SqlConnection(config.ConnectionString);
        }

        public async Task<List<Log>> GetJobLogs(Guid jobId)
        {
            const string sql = "SELECT * FROM Logs WHERE JobId = @id";
            
            return (await _db.QueryAsync<Log>(sql, new {id = jobId})).ToList();
        }

        public async Task Add(Log log)
        {
            const string sql = "INSERT INTO Logs (Id, Description, CreatedAt, JobId) Values (@Id, @Description, @CreatedAt, @JobId);";

            log.CreatedAt = DateTime.UtcNow;
            try
            {
                await _db.ExecuteAsync(sql, new { Id = log.Id, Description = log.Description, CreatedAt = log.CreatedAt, JobId = log.JobId });
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}