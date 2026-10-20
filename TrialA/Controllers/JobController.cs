using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.DTOS;
using TrialA.REPOS.interfacess;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _Repo;
        private readonly IMapper _map;

        public JobController(IUnitOfWork repo, IMapper map)
        {
            _Repo = repo;
            _map = map;
        }

        [HttpGet("getby Id")]
        public async Task<IActionResult> Get(int id) { 
        
        var e=await _Repo.jobrepo.GetbyId(id);
           

            return Ok(e);   

        }
        [HttpGet("getthird")]
        public async Task<IActionResult> Get3()
        {
           var e=await _Repo.jobrepo.GetThirdJob();
            return Ok(e);
        }


         [HttpGet("getbykey")]
        public async Task<IActionResult> Getkey(string key) { 
        
        var e=await _Repo.jobrepo.getthKeyword(key);
            

            return Ok(e);   

        }



        [HttpDelete("dlete")]
        public async Task<IActionResult> delete(int id) {

            var re =await _Repo.jobrepo.GetbyId(id);
             _Repo.jobrepo.Delete(re);
           await _Repo.save();
            return Ok();
        
        }


    }
}
