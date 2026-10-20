using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.Json;

namespace TrialA.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string Name { get; set; }
        [Required, MaxLength(1000)]
        public string Description { get; set; }

         public string? Wepsite {  get; set; }
        [Required]
        public string Location {  get; set; }

        public ICollection<Job> jobs { get; set; } =new List<Job>();







        [ForeignKey(nameof(user))]
        public int UserID { get; set; }
        public User user { get; set; }

    }
}
