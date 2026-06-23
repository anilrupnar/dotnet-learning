namespace Day03_EMICalculator
{
    class Program
    {
        static decimal CalculateEMI(decimal principal, decimal annualRate, int months)
        {
            decimal r = annualRate / 12 / 100;
            decimal power = (decimal)Math.Pow((double)(1 + r), months);
            decimal emi = principal * r * power / (power - 1);
            return Math.Round(emi, 2);
        }

        static decimal CalculateTotalPayment(decimal emi, int months)
        {
            return Math.Round(emi * months, 2);
        }

        static decimal CalculateTotalInterest(decimal totalPayment, decimal principal)
        {
            return Math.Round(totalPayment - principal, 2);
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║      EMI CALCULATOR          ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.WriteLine();

            Console.Write("Enter Loan Amount (Rs.): ");
            decimal principal = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Annual Interest Rate (%): ");
            decimal annualRate = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Loan Tenure (in months): ");
            int months = int.Parse(Console.ReadLine() ?? "0");

            decimal emi = CalculateEMI(principal, annualRate, months);
            decimal totalPayment = CalculateTotalPayment(emi, months);
            decimal totalInterest = CalculateTotalInterest(totalPayment, principal);

            Console.WriteLine();
            Console.WriteLine("══════════════════════════════");
            Console.WriteLine("         LOAN SUMMARY         ");
            Console.WriteLine("══════════════════════════════");
            Console.WriteLine($"  Loan Amount     : Rs. {principal:N2}");
            Console.WriteLine($"  Interest Rate   : {annualRate}% per year");
            Console.WriteLine($"  Tenure          : {months} months");
            Console.WriteLine("──────────────────────────────");
            Console.WriteLine($"  Monthly EMI     : Rs. {emi:N2}");
            Console.WriteLine($"  Total Payment   : Rs. {totalPayment:N2}");
            Console.WriteLine($"  Total Interest  : Rs. {totalInterest:N2}");
            Console.WriteLine("══════════════════════════════");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}