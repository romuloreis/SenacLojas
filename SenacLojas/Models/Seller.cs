using System.ComponentModel.DataAnnotations;

namespace SenacLojas.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="E-mail")]
        public string Email { get; set; }
        [Display(Name="Birth Date")]
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<SalesRecord> Sales { get; set; } = 
            new List<SalesRecord>();
    }
}
