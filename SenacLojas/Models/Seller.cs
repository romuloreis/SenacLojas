using System.ComponentModel.DataAnnotations;

namespace SenacLojas.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name="Full Name")]
        [Required]
        [MinLength(2), MaxLength(30)]
        public string Name { get; set; }
        [Display(Name="E-mail")]
        [EmailAddress(ErrorMessage = "E-mail Inválido")]
        [MinLength(7, ErrorMessage = "Insira um e-mail com mais caracteres")]
        [MaxLength(14, ErrorMessage ="E-mail muito longo")]
        public string Email { get; set; }
        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<SalesRecord> Sales { get; set; } = 
            new List<SalesRecord>();
    }
}
