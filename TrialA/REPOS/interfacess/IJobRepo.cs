using TrialA.Models;

namespace TrialA.REPOS.interfacess
{
    public interface IJobRepo : IGenericRepo<Job>
    {
        Task<Job> GetThirdJob();

        Task<Job> getthKeyword(string key);
    }
}
