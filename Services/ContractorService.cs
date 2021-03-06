using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
  public class ContractorService
  {
    private readonly ContractorRepository _repo;

    public ContractorService(ContractorRepository repo)
    {
      _repo = repo;
    }

    internal List<Contractor> Get()
    {
      List<Contractor> contractors = _repo.GetAll();
      return contractors; 
    }

    internal Contractor Get(int id)
    {
      Contractor contractor = _repo.GetById(id);
      if(contractor == null)
      {
        throw new Exception("Invalid Id");
      }
      return contractor;
    }

    internal Contractor Create(Contractor newContractor)
    {
      return _repo.Create(newContractor);
    }

    internal void Delete(int id)
    {
        Get(id);
        _repo.Delete(id);
    }

    internal Contractor Update(Contractor editedContractor)
    {
      Contractor original =  Get(editedContractor.Id);
      editedContractor.Name = editedContractor.Name != null ? editedContractor.Name : original.Name;
      return _repo.Update(editedContractor);
    }
  }
}