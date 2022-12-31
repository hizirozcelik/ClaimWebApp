using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClaimWebApp.Models
{
    public class ExpenseClaim
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Description")]
        //[Required]
        public string ExpenseDescription { get; set;} = string.Empty;

        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; } = string.Empty;

        //[Required]
        public decimal Amount { get; set; }

        public int ClaimRequestId { get; set; }

    }
}
