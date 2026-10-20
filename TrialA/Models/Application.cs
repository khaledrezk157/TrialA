using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialA.Models
{
    public class Application
    {
        public int Id { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required]
        public string Status {  get; set; }
        [MaxLength(2000)]
        public string? CoverLetter {  get; set; }


        [ForeignKey(nameof(job))]
        public int JobId { get; set; }
        public Job job { get; set; }

        [ForeignKey(nameof(candidate))]
        public int CandidteId { get; set; }
        public CandidateProfile candidate { get; set; }
    }
}
