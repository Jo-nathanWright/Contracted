using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContractorController : ControllerBase
    {
    private readonly ContractorService _cs;

    public ContractorController(ContractorService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Contractor>> Get()
    {
        try
        {
            List<Contractor> contractors = _cs.Get();
            return Ok(contractors);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    
    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id){
        try
        {
        Contractor contractor = _cs.Get(id);
        return Ok(contractor);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }
  
    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
    {
        try
        {
        Contractor contractor = _cs.Create(newContractor);
        return Ok(contractor);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }
  
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
        try
        {
        _cs.Delete(id);
        return Ok("Successfully Deleted");
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }
  }
}