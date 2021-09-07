using System.ComponentModel.DataAnnotations;

namespace Contracted.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public int ContractorId { get; set; }
  }
}