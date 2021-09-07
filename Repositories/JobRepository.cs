using System.Data;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
  public class JobRepository
  {
    private readonly IDbConnection _db;

    public JobRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Job Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (accountId, companyId, ContractorId)
      VALUES
      (@AccountId, @CompanyId, @ContractorId);
      SELECT LAST_INSERT_ID();
      ";
      newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
      return newJob;
    }
  }
}