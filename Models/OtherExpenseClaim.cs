using System.ComponentModel.DataAnnotations;

namespace ClaimWebApp.Models
{
    public class OtherExpenseClaim
    {
        [Key]
        public int Id { get; set; }
       // [Required]
        public string Type { get; set; } = string.Empty;
        //[Required]
        public decimal Cost { get; set; }

        public int ClaimRequestId { get; set; }
    }
}
