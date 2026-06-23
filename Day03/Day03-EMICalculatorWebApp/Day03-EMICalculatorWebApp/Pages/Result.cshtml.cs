using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Day03_EMICalculatorWebApp.Pages
{
    public class ResultModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public decimal? Principal { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? AnnualRate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? TenureMonths { get; set; }

        public decimal EMI { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal TotalInterest { get; set; }

        public IActionResult OnGet()
        {
            // Validate query params
            if (!Principal.HasValue || !AnnualRate.HasValue || !TenureMonths.HasValue)
            {
                return RedirectToPage("Index");
            }

            EMI = CalculateEMI(Principal.Value, AnnualRate.Value, TenureMonths.Value);
            TotalPayment = Math.Round(EMI * TenureMonths.Value, 2);
            TotalInterest = Math.Round(TotalPayment - Principal.Value, 2);

            return Page();
        }

        private static decimal CalculateEMI(decimal principal, decimal annualRate, int months)
        {
            decimal r = annualRate / 12 / 100;
            decimal power = (decimal)Math.Pow((double)(1 + r), months);
            decimal emi = principal * r * power / (power - 1);
            return Math.Round(emi, 2);
        }
    }
}
