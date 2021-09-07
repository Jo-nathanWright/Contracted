using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CompanyController : ControllerBase
    {
    private readonly CompanyService _cs;

    public CompanyController(CompanyService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Company>> Get()
    {
        try
        {
            List<Company> companies = _cs.Get();
            return Ok(companies);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    
    [HttpGet("{id}")]
    public ActionResult<Company> Get(int id){
        try
        {
        Company company = _cs.Get(id);
        return Ok(company);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }
  
    [HttpPost]
    public ActionResult<Company> Create([FromBody] Company newCompany)
    {
        try
        {
        Company company = _cs.Create(newCompany);
        return Ok(company);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }
  
    [HttpPut("{id}")]
    public ActionResult<Company> Update(int id, [FromBody] Company editedCompany)
    {
        try
        {
        editedCompany.Id = id;
        Company company = _cs.Update(editedCompany);
        return Ok(company);
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