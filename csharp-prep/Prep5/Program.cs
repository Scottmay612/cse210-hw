using System;

class Program
{
    static void Main(string[] args)
    {
        //Welcome message
        DisplayWelcome();

        //learns name from user
        string userName = PromptUserName();

        //asks user for number
        int number = PromptUserNumber();

        //squares the number
        int squared = SquareNumber(number);

        //displays the result
        DisplayResult(userName, squared);

        //Function DisplayWelcome
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        //Function PrompUserName
        static string PromptUserName()
        {
            Console.Write("What is your name? ");
            string newLine = Console.ReadLine();

            return newLine;
        }

        //Function PromptUserNumber
        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number? ");
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        // Function SquareNumber
        static int SquareNumber(int number)
        {
            int squared = number * number;
            return squared;
        }
        
        //Function Display Result
        static void DisplayResult(string name, int squared)
        {
            Console.WriteLine($"Hello, {name}! The square of your number is {squared}.");
        }
    }
}