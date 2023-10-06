using System;
using System.Security.Cryptography.X509Certificates;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal1 = new Journal();
        string optionChoice = "";
        Console.WriteLine("Welcome to your Journal!");
        while (optionChoice != "5")
        {
            Console.WriteLine("Choose an option from the following list by typing " +
                            "in the corresponding number: ");
            Console.WriteLine("");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            optionChoice = Console.ReadLine();


            switch (optionChoice)
            {
                case "1":
                    journal1.Write();
                    break;

                case "2":
                    // Display the contents of the journal.
                    journal1.DisplayJournal();
                    break;

                case "3":
                    // Load a journal from a file.
                    journal1.LoadJournal();
                    break;

                case "4":
                    // Save the journal to a file.
                    journal1.SaveJournal();
                    break;

                case "5":
                    // Quit the application.
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}