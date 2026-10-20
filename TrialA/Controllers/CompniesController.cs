using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.REPOS.interfacess;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompniesController : ControllerBase
    {
        private readonly IUnitOfWork _Repo;

        public CompniesController(IUnitOfWork repo)
        {
            _Repo = repo;
        }
    }
}
