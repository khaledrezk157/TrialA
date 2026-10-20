using TrialA.Models;

namespace TrialA.REPOS.interfacess
{
    public interface IUnitOfWork
    {
      

        public IGenericRepo<CandidateProfile> Profile { get;  }
        public IApplication application { get; }
      
        public IJobRepo jobrepo { get;  }
        public ICompnyRepo compnyrepo { get;  }


        Task save();
    }
}
