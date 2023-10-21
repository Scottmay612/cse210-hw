using System;

class Program
{
    // To exceed requirements, my program is able to block out only remaining 
    // words instead of picking randomly from the whole list every time.
    static void Main(string[] args)
    {
        // Create new Reference object.
        Reference reference1 = new Reference("John", "3", "16");

        // Second reference with start and end verses:
        // Reference reference1 = new Reference("Proverbs", "3", "5", "6");

        // Create new Scripture object.
        Scripture scripture1 = new Scripture();

        // Use GetWordCount to store the remaining steps.
        int stepsRemaning = scripture1.GetWordCount();

        // Declare the user's response.
        string steps = "";

        // Continue looping as long as the user doesn't type quit and there 
        // are words remaining in the scripture.
        while (steps != "quit" && stepsRemaning >= -2)
        {
            if (steps == "")
            {
                // Display options to user with blank line underneath.
                Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
                Console.WriteLine();

                // Reduce stepsRemaining by 1 every iteration.
                stepsRemaning -= 3;

                // Display scripture reference.
                reference1.DisplayReference();

                // Display scripture text.
                scripture1.Display();

                // Blank out three new words in the words list.
                scripture1.RandomString();

                // Get user response.
                steps = Console.ReadLine();

                // Clear console.
                Console.Clear();
            }
            else
            {
                // Handle the case where they don't press enter or type 'quit'.
                Console.Write("Sorry, please press enter or type 'quit' to finish: ");
                steps = Console.ReadLine();
            }

        }
    }
}