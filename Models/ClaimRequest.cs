
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ClaimWebApp.Models
{
    public class ClaimRequest
    {
        [Key]
        public int Id { get; set; }

        public string Status { get; set; } = string.Empty;

        [Display(Name = "First Name")]
        //[Required]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        //[Required]
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Display(Name = "Please select claim type")]
        //[Required]
        public string ClaimType { get; set; } = string.Empty;

        [BindProperty]
        [Display(Name = "I have other Expenses to claim")]
        public bool IsOtherExpense { get; set; } = false;

        [Display(Name = "Other Expense Total")]
        public decimal OtherExpenseTotal { get; set; }

        [Display(Name = "Mileage Total")]
        public decimal MileageTotal { get; set; }

        [Display(Name = "Expense Total")]
        public decimal ExpenseTotal { get; set; }
        public List<MileageClaim> MileageClaims { get; set; }
        public List<OtherExpenseClaim> OtherExpenseClaims { get; set; }
        public List<ExpenseClaim> ExpenseClaims { get; set; }

        public ClaimRequest()
        {
            MileageClaims = new List<MileageClaim> { new MileageClaim() };
            OtherExpenseClaims = new List<OtherExpenseClaim> { new OtherExpenseClaim() };
            ExpenseClaims = new List<ExpenseClaim> { new ExpenseClaim() };
        }
    }
}
