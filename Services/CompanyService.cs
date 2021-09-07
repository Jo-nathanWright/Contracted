using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class CompanyService
    {
    private readonly CompanyRepository _repo;

    public CompanyService(CompanyRepository repo)
    {
      _repo = repo;
    }

    internal List<Company> Get()
    {
      List<Company> companies = _repo.GetAll();
      return companies; 
    }

    internal Company Get(int id)
    {
      Company company = _repo.GetById(id);
      if(company == null)
      {
        throw new Exception("Invalid Id");
      }
      return company;
    }

    internal Company Create(Company newCompany)
    {
      return _repo.Create(newCompany);
    }

    internal void Delete(int id)
    {
        Get(id);
        _repo.Delete(id);
    }

    internal Company Update(Company editedCompany)
    {
      Company original =  Get(editedCompany.Id);
      editedCompany.Name = editedCompany.Name != null ? editedCompany.Name : original.Name;
      return _repo.Update(editedCompany);
    }
  }
}