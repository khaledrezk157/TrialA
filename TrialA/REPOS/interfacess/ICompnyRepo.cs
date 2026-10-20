

using TrialA.Models;
namespace TrialA.REPOS.interfacess
  
{
    public interface ICompnyRepo:IGenericRepo<Company>
    {
        Task<Company> getmost();
    }
}
