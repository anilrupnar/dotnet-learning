# .NET / C# Learning Journey

Daily practice and small projects as I learn C# and .NET, working toward becoming a .NET developer.

## Progress Log

| Day | Project | Type | What I Learned |
|-----|---------|------|-----------------|
| Day 1 | [Number Guessing Game](./Day01-NumberGuessingGame) | Console App | Variables, if/else, while loops, Random class, input validation with TryParse, null handling with ??, string interpolation |
| Day 2 | [Number Guessing Game Web App](./Day02-NumberGuessingGameWebApp) | Web App | ASP.NET Core Razor Pages, Razor syntax (.cshtml), Model binding, OnGet/OnPost page handlers, Session state, Tag Helpers |
| Day 3 | [EMI Calculator](./Day03/Day03-EMICalculator) | Console App | Methods, financial calculations, input validation, mathematical formulas, numeric formatting |
| Day 3 | [EMI Calculator Web App](./Day03/Day03-EMICalculatorWebApp) | Web App | Razor Pages, form handling, model binding, financial calculations, result display |
| Day 4 | [Student Grade Tracker Web App](./Day04-StudentGradeTrackerWebApp) | Web App | ASP.NET Core Razor Pages, Model Binding, Form Validation, OOP Concepts, Grade Calculation, Dynamic Data Display |

## Projects

### Day 1 — Number Guessing Game (Console App)
> Built the same game logic as a classic terminal application.

- Language: C# / .NET 8
- Type: Console Application
- The app picks a random number between 1 and 100
- User guesses via terminal input
- App responds with Too Low / Too High hints
- Game ends when the correct number is guessed

### Day 2 — Number Guessing Game (Web App)
> Rebuilt the same game from Day 1 as a browser-based web application.

- Language: C# / .NET 8
- Framework: ASP.NET Core Razor Pages
- Same game logic, now running in the browser
- User submits guesses via a web form
- App responds with Too Low / Too High feedback on the page
- Play Again button resets the game

### Day 3 — EMI Calculator (Console App)
> Built a console-based EMI calculator to calculate loan repayment details.

- Language: C# / .NET 8
- Type: Console Application
- Accepts Loan Amount, Interest Rate, and Loan Tenure
- Calculates Monthly EMI using the standard EMI formula
- Displays Monthly EMI, Total Payment, and Total Interest
- Uses methods and input validation for better code structure

### Day 3 — EMI Calculator (Web App)
> Rebuilt the EMI Calculator as a browser-based web application.

- Language: C# / .NET 8
- Framework: ASP.NET Core Razor Pages
- Accepts loan details through a web form
- Calculates EMI instantly
- Displays Monthly EMI, Total Payment, and Total Interest
- Provides a simple and user-friendly interface

### Day 4 — Student Grade Tracker Web App
> Built a browser-based application to manage student marks and calculate grades.

- Language: C# / .NET 8
- Framework: ASP.NET Core Razor Pages
- Accepts student details and marks through a web form
- Calculates Total Marks, Percentage, and Grade
- Displays results dynamically on the page
- Uses Model Binding and Validation
- Implements Classes and OOP concepts
- Provides a clean and user-friendly interface

## Goals

- [ ] Build a project every day
- [ ] Become a job-ready .NET developer
