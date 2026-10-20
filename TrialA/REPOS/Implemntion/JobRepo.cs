using Microsoft.EntityFrameworkCore;
using TrialA.DATA;
using TrialA.Models;
using TrialA.REPOS.interfacess;

namespace TrialA.REPOS.Implemntion
{
    public class JobRepo : GenericRepo<Job>, IJobRepo
    {
        private readonly Appdbcontext _db;
        public JobRepo(Appdbcontext db) : base(db)
        {
            _db = db;
        }

        public async Task<Job> GetThirdJob()
        {
           var s=await _db.Set<Job>().OrderByDescending(a=>a.Salary).Skip(2).Take(1).FirstOrDefaultAsync();

            return s;
        }

        public async Task<Job> getthKeyword(string key)
        {
           var f=await _db.Set<Job>().Where(a=>a.Title==key).FirstOrDefaultAsync();
           var ff=await _db.Set<Job>().Where(a=>a.Description==key).FirstOrDefaultAsync();
            if (ff == null)
            {
                return null;
               
            }
            else if (f != null) {

                return f;
            }
            else if (f == null) {

                return null;
            }

            return ff;
            
        }
    }
}
