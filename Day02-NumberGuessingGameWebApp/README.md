# 🎯 Number Guessing Game

A fun, browser-based number guessing game built with **ASP.NET Core Razor Pages**.

---

## 🎮 How to Play

1. The app picks a secret random number between **1 and 100**
2. Type your guess and click **Guess!**
3. The app tells you if your guess is **Too Low 📉** or **Too High 📈**
4. Keep guessing until you find the correct number 🎉
5. Click **Play Again** to start a new game

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET 8) |
| Framework | ASP.NET Core Razor Pages |
| Session Storage | ASP.NET Core Session (server-side) |
| Frontend | HTML + CSS (no JavaScript framework) |

---

## 📁 Project Structure

```
NumberGuessingGameWebApp/
├── Pages/
│   ├── Index.cshtml          # Game UI (HTML + Razor syntax)
│   ├── Index.cshtml.cs       # Game logic (C# code-behind)
│   ├── Shared/
│   │   └── _Layout.cshtml    # Shared layout
│   └── _ViewImports.cshtml
├── wwwroot/
│   ├── css/                  # Stylesheets
│   └── js/                   # JavaScript files
├── Program.cs                # App startup + session config
├── appsettings.json          # App configuration
└── NumberGuessingGameWebApp.csproj
```

---

## 🚀 Getting Started Locally

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Run the app

```bash
# Clone the repo
git clone https://github.com/anilrupnar/dotnet-learning.git
cd NumberGuessingGameWebApp

# Run the app
dotnet run
```

Open your browser at `https://localhost:7073` — the game loads instantly.

---

## 🔑 Key Concepts Used

### Session State
The secret target number is stored in **ASP.NET Core Session** so it persists across multiple HTTP requests (each guess is a separate request).

```csharp
// Store the target number
HttpContext.Session.SetInt32("Target", new Random().Next(1, 101));

// Read it back on the next request
int target = HttpContext.Session.GetInt32("Target") ?? 0;
```

### Razor Pages
The app uses two paired files per page:
- `.cshtml` — HTML markup with `@` C# expressions (what the player sees)
- `.cshtml.cs` — Pure C# logic with `OnGet()` and `OnPost()` handlers (what the app does)

### OnGet vs OnPost
- `OnGet()` — runs when the page first loads → starts a new game
- `OnPost()` — runs when the player submits a guess → checks and responds

---

## 🐛 Issues Faced & How I Solved Them

### Issue 1: `Element 'button' cannot be nested inside element 'a'`

**What happened:**
When adding the Play Again button, I wrote:
```razor
<a href="/"><button type="button">🔄 Play Again</button></a>
```
Visual Studio flagged this as an HTML validation warning — nesting a `<button>` inside an `<a>` tag is invalid HTML.

**Why it's a problem:**
Browsers handle this inconsistently, and it's against the HTML spec. A `<button>` and `<a>` are both interactive elements and cannot be nested inside each other.

**How I fixed it:**
Replaced it with a proper HTML form that sends a GET request to `/`:
```razor
@if (Model.GameOver)
{
    <form method="get" action="/">
        <button type="submit">🔄 Play Again</button>
    </form>
}
```
This is cleaner — a GET request to `/` reloads the page, triggers `OnGet()`, and starts a fresh game.

---

### Issue 2: `Declare types in namespaces` warning

**What happened:**
After writing the `IndexModel` class in `Index.cshtml.cs`, Visual Studio showed a warning:
```
IDE0130: Declare types in namespaces
```

**Why it's a problem:**
In C#, it is best practice to always declare classes inside a namespace. Without a namespace, the class sits in the global namespace which can cause naming conflicts in larger projects.

**How I fixed it:**
Wrapped the entire class inside a proper namespace:
```csharp
namespace NumberGuessingGameWebApp.Pages
{
    public class IndexModel : PageModel
    {
        // game logic here
    }
}
```
The namespace `NumberGuessingGameWebApp.Pages` matches the project name and the `Pages` folder, which is the standard convention in ASP.NET Core Razor Pages.

---

## 💡 What I Learned

- How Razor Pages work — pairing `.cshtml` (UI) with `.cshtml.cs` (logic)
- How `OnGet()` and `OnPost()` replace the console app's loop and `Console.ReadLine()`
- Why session state is needed in web apps (stateless HTTP has no memory between requests)
- How to properly structure C# classes with namespaces
- Valid HTML rules — interactive elements like `<button>` cannot be nested inside `<a>`

---

## 📸 Screenshots

> Add screenshots of your running game here!

---

## 👨‍💻 Author

**Anil Rupnar**
- GitHub: [@anilrupnar](https://github.com/anilrupnar)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).