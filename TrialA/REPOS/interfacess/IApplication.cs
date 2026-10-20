using TrialA.DTOS;
using TrialA.Models;

namespace TrialA.REPOS.interfacess
{
    public interface IApplication:IGenericRepo<Application>
    {
        Task patch(int id, updateApplicationDto dto);

    }
}
