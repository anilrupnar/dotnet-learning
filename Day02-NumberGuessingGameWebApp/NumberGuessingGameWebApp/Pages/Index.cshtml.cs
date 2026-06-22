using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NumberGuessingGameWebApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int Guess { get; set; }

        public string Message { get; set; } = "";
        public int Attempts { get; set; } = 0;
        public bool GameOver { get; set; } = false;

        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("Target") == null)
            {
                HttpContext.Session.SetInt32("Target", new Random().Next(1, 101));
                HttpContext.Session.SetInt32("Attempts", 0);
            }

            Attempts = HttpContext.Session.GetInt32("Attempts") ?? 0;
        }

        public IActionResult OnPost()
        {
            int target = HttpContext.Session.GetInt32("Target")
                         ?? new Random().Next(1, 101);
            int attempts = (HttpContext.Session.GetInt32("Attempts") ?? 0) + 1;

            HttpContext.Session.SetInt32("Attempts", attempts);
            Attempts = attempts;

            if (Guess < target)
                Message = "📉 Too low! Try a higher number.";
            else if (Guess > target)
                Message = "📈 Too high! Try a lower number.";
            else
            {
                Message = $"🎉 Correct! You guessed it in {attempts} attempts!";
                GameOver = true;
                HttpContext.Session.Clear();
            }

            return Page();
        }
    }
}