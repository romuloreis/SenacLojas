using System.ComponentModel.DataAnnotations;

namespace SenacLojas.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public SaleStatus Status { get; set; }

        [Display(Name="Seller's Name")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }

    }

    public enum SaleStatus : int { 
        PENDING = 0,
        BILLED = 1,
        CANCELED = 2
    }
}
