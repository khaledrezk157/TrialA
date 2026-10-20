using AutoMapper;
using TrialA.DTOS;

namespace TrialA.mapperrr
{
    public class candlitProfile: Profile
    {
        public candlitProfile()
        {
            CreateMap<candlitProfile, CandilitUpdate>();
        }
    }
}
