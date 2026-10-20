using Microsoft.EntityFrameworkCore;
using TrialA.DATA;
using TrialA.DTOS;
using TrialA.Models;
using TrialA.REPOS.interfacess;

namespace TrialA.REPOS.Implemntion
{
    public class AplicationRepo : GenericRepo<Application>, IApplication
    {
        private readonly Appdbcontext db;
        public AplicationRepo(Appdbcontext db) : base(db)
        {
           this. db = db;
        }

        public async Task patch(int id,updateApplicationDto dto)
        {

            var e=await db.applications.Where(a=>a.Id==id).FirstOrDefaultAsync();
            if (dto.Status == "Accepted" || dto.Status == "Panding" || dto.Status == "UnderReview")
            {
                e.Status = dto.Status;
            }

        }
    }
}
