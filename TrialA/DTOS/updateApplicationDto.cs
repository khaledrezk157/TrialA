using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOS
{
    public class updateApplicationDto
    {
        [Required]
        public string Status { get; set; }
    }
}
