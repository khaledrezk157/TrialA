using System.ComponentModel.DataAnnotations;

namespace TrialA.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100),MinLength(3)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role {  get; set; }
        [Required]
        public DateTime CreatedAt {  get; set; }
        public CandidateProfile CProfile { get; set; }   

        public ICollection<Company> Company { get; set; }=new List<Company>();

    }
}
