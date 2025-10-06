using System.ComponentModel.DataAnnotations;

namespace SenacLojas.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name="Department Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Seller> Sellers { get; set; } = 
            new List<Seller>();
    }
}
