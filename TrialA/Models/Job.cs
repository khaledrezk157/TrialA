using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialA.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title {  get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location {  get; set; }
        [Required,Range(0,100000)]
        public decimal Salary {  get; set; }
        [Required]
        public string EmployeeTypr {  get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime DeadTime { get; set; }
        [Required]
        public string Status {  get; set; }


        public ICollection<Application> Application { get; set; } = new List<Application>();



        [ForeignKey(nameof(company))]
        public int companyId { get; set; }
        public Company company { get; set; }





    }
}
