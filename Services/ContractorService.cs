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
  }
}