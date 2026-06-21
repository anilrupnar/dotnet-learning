Console.WriteLine("Welcome to the Number Guessing Game!");
Console.WriteLine("I'm thinking of a number between 1 and 100.");

Random random = new Random();
int secretNumber = random.Next(1, 101);

int attempts = 0;

bool hasGuessedCorrectly = false;

while (!hasGuessedCorrectly)
{
    Console.WriteLine("Enter your guess:");
    string input = Console.ReadLine() ?? "";
    bool isValidNumber = int.TryParse(input, out int guess);

    if (!isValidNumber)
    {
        Console.WriteLine("That's not a valid number. Try again.");
        continue;
    }
    attempts++;


    if (guess == secretNumber)
    {
        Console.WriteLine($"Correct! You guessed it in {attempts} attempts!");
        hasGuessedCorrectly = true;
    }
    else if (guess < secretNumber)
    {
        Console.WriteLine("Too low!");
    }
    else
    {
        Console.WriteLine("Too high!");
    }
}