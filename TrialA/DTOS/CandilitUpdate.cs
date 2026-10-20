using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOS
{
    public class CandilitUpdate
    {
        public string Phone { get; set; }

        public string? ResumeUrl { get; set; }
        [Required, MaxLength(500)]
        public string Skill { get; set; }
        [Range(0, 50)]
        public int yearsOfExperience { get; set; }
    }
}
