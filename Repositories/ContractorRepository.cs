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

    internal Contractor GetById(int id)
    {
      string sql = @"
      SELECT 
        c.*
      FROM contractor c
      WHERE c.id = @id
      ";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal Contractor Create(Contractor newContractor)
    {
      string sql = @"
      INSERT INTO contractor
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();
      ";
      newContractor.Id = _db.ExecuteScalar<int>(sql, newContractor);
      return newContractor;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractor WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    internal Contractor Update(Contractor editedContractor)
    {
      string sql = @"
      UPDATE contractor
      SET
        name = @Name
      WHERE id = @id;
      ";
      _db.Execute(sql, editedContractor);
      return editedContractor;
    }
  }
}