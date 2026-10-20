using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.DTOS;
using TrialA.REPOS.interfacess;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _Repo;

        public ApplicationController(IUnitOfWork repo)
        {
            _Repo = repo;
        }


        [HttpPatch]
        public async Task<IActionResult>updatestatus(int id,updateApplicationDto dto)
        {

            var e= _Repo.application.patch(id,dto);
           await _Repo.save();

            return Ok();

        }
        [HttpGet]
        public async Task<IActionResult> getall()
        {
            var e=await _Repo.application.GetAll();

            return Ok(e);
        }
    }
}
