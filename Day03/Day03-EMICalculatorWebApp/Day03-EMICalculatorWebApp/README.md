# 🎯 EMI Calculator Web App

A simple, browser-based EMI (Equated Monthly Installment) calculator built with **ASP.NET Core Razor Pages**.

---

## 🎮 How to Use

1. Open the app in your browser (run locally via Visual Studio or dotnet run).
2. On the Index page enter:
   - Loan Amount (Principal) in Rs.
   - Annual Interest Rate (%)
   - Tenure (months)
3. Click "Calculate EMI".
4. You will be redirected to a styled Result page showing the Loan Summary (Monthly EMI, Total Payment, Total Interest).
5. Click "Calculate Again" to return to the input page and start a new calculation.

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Language | C# (.NET 8) |
| Framework | ASP.NET Core Razor Pages |
| Frontend | HTML + CSS (Bootstrap used for layout) |

---

## 📁 Project Structure

```
Day03-EMICalculatorWebApp/
├── Pages/
│   ├── Index.cshtml          # Input UI (HTML + Razor)
│   ├── Index.cshtml.cs       # Input page model (OnGet/OnPost)
│   ├── Result.cshtml         # Result UI (styled summary)
│   ├── Result.cshtml.cs      # Result page model (calculations)
│   └── Shared/_Layout.cshtml # Shared layout (header/footer)
├── wwwroot/                  # static assets (lib, css, js)
├── Program.cs                # App startup
├── appsettings.json          # App configuration
└── Day03-EMICalculatorWebApp.csproj
```

---

## 🚀 Getting Started Locally

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022/2026 or VS Code with C# extensions

### Run the app

```sh
# From repo root
dotnet restore
dotnet build
dotnet run --project Day03-EMICalculatorWebApp

# Or open Day03-EMICalculatorWebApp.slnx in Visual Studio and run (F5)
```

Open your browser at `https://localhost:{port}` (Visual Studio chooses the port).

---

## 🔑 Key Concepts Used

### Razor Pages
- Pages are pairs of `.cshtml` (markup) and `.cshtml.cs` (page model).
- `OnGet()` runs on page load; `OnPost()` runs for form submissions.

### POST-Redirect-GET
- The Index form POST redirects to `/Result` with inputs as query parameters. Result calculates values in `OnGet()` and renders them. This avoids double-posts on refresh.

---

## 🐛 Issues Faced & How I Solved Them

### Issue 1: Razor parse error with percent sign
**Problem:** A literal `%` immediately after a Razor expression caused a compile error.

**Fix:** Render the value via string interpolation, e.g. `@($"{Model.AnnualRate}% per year")` so Razor sees a single expression.

### Issue 2: Namespace mismatch
**Problem:** `IndexModel` was declared in a namespace that didn't match the project's root namespace, causing generated Razor code to not find the PageModel.

**Fix:** Updated the namespace in `Index.cshtml.cs` to `Day03_EMICalculatorWebApp.Pages` to match `RootNamespace`.

### Issue 3: Full HTML document inside Index.cshtml while using a shared layout
**Problem:** `Index.cshtml` included `<html>`, `<head>`, `<body>`, causing nested document structure and layout oddities.

**Fix:** Removed the full-page wrapper and made Index a Razor fragment that uses `_Layout.cshtml`.

### Issue 4: CSS collision with Bootstrap `.container`
**Problem:** Page-level styles overrode `.container`, which changed header/footer visuals.

**Fix:** Scoped the card styles to `.emi-card` to avoid overriding Bootstrap classes used by the layout.

### Issue 5: Hot Reload / Debugging behavior
**Problem:** When debugging, new files/edits may not be picked up until restart or Hot Reload is applied.

**Workaround:** Use Visual Studio's Hot Reload button or stop & restart the debugger.

---

## 💡 What I Learned

- Proper Razor syntax for mixing literals with `@` expressions.
- Keep PageModel classes in matching namespaces.
- Use shared layouts correctly — don't duplicate `<html>`/`<body>` in pages.
- Scope page-specific CSS to avoid interfering with global/Bootstrap styles.
- POST-Redirect-GET is useful for showing results on a separate page.

---

## 👨‍💻 Author
**Anil Rupnar**  
GitHub: [@anilrupnar](https://github.com/anilrupnar)

---

## 📄 License
This project is open source and available under the MIT License.
