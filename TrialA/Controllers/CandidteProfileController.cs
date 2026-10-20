using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.DTOS;
using TrialA.Models;
using TrialA.REPOS.interfacess;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidteProfileController : ControllerBase
    {
        private readonly IUnitOfWork _Repo;
        private readonly IMapper map;

        public CandidteProfileController(IUnitOfWork repo, IMapper map)
        {
            _Repo = repo;
            this.map = map;
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Updatee(int id,CandilitUpdate dto) { 
        
        var f=await _Repo.Profile.GetbyId(id);

            f.Phone = dto.Phone;
            f.Skill = dto.Skill;
            f.ResumeUrl = dto.ResumeUrl;
            f.yearsOfExperience = dto.yearsOfExperience;

            
         
            _Repo.Profile.Update(f);
            _Repo.save();
            return Ok();
        
        
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            return Ok(await _Repo.Profile.GetAll());

        }
    
    
    }
}
