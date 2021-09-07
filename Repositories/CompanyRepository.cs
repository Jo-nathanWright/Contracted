using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
    public class CompanyRepository
    {
    private readonly IDbConnection _db;

    public CompanyRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Company> GetAll()
    {
      string sql = @"
      SELECT *
      FROM company
      ";
      return _db.Query<Company>(sql).ToList();
    }

    internal Company GetById(int id)
    {
      string sql = @"
      SELECT 
        c.*
      FROM company c
      WHERE c.id = @id
      ";
      return _db.QueryFirstOrDefault<Company>(sql, new { id });
    }

    internal Company Create(Company newCompany)
    {
      string sql = @"
      INSERT INTO company
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();
      ";
      newCompany.Id = _db.ExecuteScalar<int>(sql, newCompany);
      return newCompany;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM company WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    internal Company Update(Company editedCompany)
    {
      string sql = @"
      UPDATE company
      SET
        name = @Name
      WHERE id = @id;
      ";
      _db.Execute(sql, editedCompany);
      return editedCompany;
    }
  }
}