using TrialA.DATA;
using TrialA.Models;
using TrialA.REPOS.interfacess;

namespace TrialA.REPOS.Implemntion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Appdbcontext _context;

        public UnitOfWork(Appdbcontext context, IGenericRepo<CandidateProfile> profile, IApplication application, IJobRepo jobrepo, ICompnyRepo compnyrepo)
        {
            _context = context;
            Profile = profile;
            this.application = application;
        
            this.jobrepo = jobrepo;
            this.compnyrepo = compnyrepo;
        }

        public IGenericRepo<CandidateProfile> Profile { get; }

        public IApplication application {get;}

      

        public IJobRepo jobrepo {get;}

        public ICompnyRepo compnyrepo {get;}

        public async Task save()
        {
          await _context.SaveChangesAsync();
        }
    }
}
