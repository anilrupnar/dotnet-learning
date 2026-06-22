# .NET / C# Learning Journey

Daily practice and small projects as I learn C# and .NET, working toward becoming a .NET developer.

## Progress Log

| Day | Project | Type | What I Learned |
|-----|---------|------|-----------------|
| Day 1 | [Number Guessing Game](./Day01-NumberGuessingGame) | Console App | Variables, if/else, while loops, Random class, input validation with TryParse, null handling with ??, string interpolation |
| Day 2 | [Number Guessing Game Web App](./Day02-NumberGuessingGameWebApp) | Web App | ASP.NET Core Razor Pages, Razor syntax (.cshtml), Model binding, OnGet/OnPost page handlers, Session state, Tag Helpers |

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

## Why the Same Game Twice?
Building the same project in two different ways helped me clearly see the difference between:
- **Console App** — simple input/output in the terminal, great for learning core C# logic
- **Web App** — browser-based UI, page lifecycle, form handling, and server-side state

## Goals
- [ ] Build a project every day
- [ ] Progress from Console → Web → API → Full Stack
- [ ] Become a job-ready .NET developer