using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace TrialA.Models
{
    public class CandidateProfile
    {
        public int Id { get; set; }
        [Required,Phone]
        public string Phone { get; set; }
        
        public string? ResumeUrl { get; set; }
        [Required,MaxLength(500)]
        public string Skill {  get; set; }
        [Range(0,50)]
        public int yearsOfExperience {  get; set; }
        public ICollection<Application>applications { get; set; }=new List<Application>();


        [ForeignKey(nameof(user))]
        public int UserID {  get; set; }
        public User user { get; set; }

    }
}
