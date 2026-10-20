using AutoMapper;
using TrialA.DTOS;
using TrialA.Models;

namespace TrialA.mapperrr
{
    public class JobProfile: Profile
    {
        public JobProfile()
        {
            CreateMap< Job, JobDto>();
        }

    }
}
