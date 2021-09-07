using System;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
  public class JobService
  {
    private readonly JobRepository _repo;

    public JobService(JobRepository repo)
    {
      _repo = repo;
    }

    internal Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }
  }
}