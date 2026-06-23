using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Day03_EMICalculatorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        // Input fields with validation
        [BindProperty]
        [Required(ErrorMessage = "Loan amount is required")]
        [Range(1000, 10000000, ErrorMessage = "Enter amount between Rs.1,000 and Rs.1,00,00,000")]
        public decimal? Principal { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Interest rate is required")]
        [Range(0.1, 30, ErrorMessage = "Rate must be between 0.1% and 30%")]
        public decimal? AnnualRate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Tenure is required")]
        [Range(1, 360, ErrorMessage = "Tenure must be between 1 and 360 months")]
        public int? TenureMonths { get; set; }

        // Output fields
        public decimal EMI { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public bool ResultVisible { get; set; } = false;

        public void OnGet() { }

        public IActionResult OnPost()
        {
            // Check all validations before calculating
            if (!ModelState.IsValid)
                return Page();

            // Redirect to results page with values as query parameters
            return RedirectToPage("Result", new
            {
                Principal = Principal,
                AnnualRate = AnnualRate,
                TenureMonths = TenureMonths
            });
        }

        // Static reusable method — same formula as console app
        private static decimal CalculateEMI(decimal principal, decimal annualRate, int months)
        {
            decimal r = annualRate / 12 / 100;
            decimal power = (decimal)Math.Pow((double)(1 + r), months);
            decimal emi = principal * r * power / (power - 1);
            return Math.Round(emi, 2);
        }
    }
}