using TrialA.DATA;
using TrialA.Models;
using TrialA.REPOS.interfacess;

namespace TrialA.REPOS.Implemntion
{
    public class CompnyRepo : GenericRepo<Company>, ICompnyRepo
    {
        
        public CompnyRepo(Appdbcontext db) : base(db)
        {
        }

        public Task<Company> getmost()
        {
            throw new NotImplementedException();
        }
    }
}
