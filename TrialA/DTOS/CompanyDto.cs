using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOS
{
    public class CompanyDto
    {

        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        
    }
}
