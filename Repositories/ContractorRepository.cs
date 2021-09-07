using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
  public class ContractorRepository
  {
    private readonly IDbConnection _db;

    public ContractorRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Contractor> GetAll()
    {
      string sql = @"
      SELECT *
      FROM contractor
      ";
      return _db.Query<Contractor>(sql).ToList();
    }
  }
}