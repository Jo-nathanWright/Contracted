
using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class JobsController : ControllerBase
    {
    private readonly JobService _js;

    public JobsController(JobService js)
    {
      _js = js;
    }

    [HttpPost]
    public async Task<ActionResult<Job>> Create([FromBody] Job newJob)
    {
        try
        {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newJob.AccountId = userInfo.Id;
        Job created = _js.Create(newJob);
        return Ok(created);
      }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
  }
}