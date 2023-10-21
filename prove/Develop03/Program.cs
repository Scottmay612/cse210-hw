using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference1 = new Reference("John", "3", "16");
        // Reference reference1 = new Reference("Proverbs", "3", "5", "6");
        Scripture scripture1 = new Scripture();
        int stepsRemaning = scripture1.GetWordCount();
        string steps = "";
        // while (steps == "" && scripture1.CheckNumber())
        while (steps == "" && stepsRemaning >= 0)
        {
            if (steps != "quit")
            {
                stepsRemaning -= 1;
                Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
                reference1.GetReference();
                scripture1.Display();
                scripture1.RandomString();
                steps = Console.ReadLine();
                Console.Clear();
            }
            else
            {
                steps = "quit";
            }
        }
    }
}