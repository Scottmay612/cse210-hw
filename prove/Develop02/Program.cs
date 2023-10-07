using System;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        // I showed creativity by added a "Vent" option for the user to vent 
        // out their feelings without having to save it anywhere.

        Journal journal1 = new Journal();
        string optionChoice = "";
        Console.WriteLine("Welcome to your Journal!");
        while (optionChoice != "6")
        {
            // Present journal options to the user.
            Console.WriteLine("Choose an option from the following list by typing " +
                            "in the corresponding number: ");
            Console.WriteLine("");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Vent");
            Console.WriteLine("6. Quit");
            optionChoice = Console.ReadLine();

            // Match the user's input with the corresponding case.
            switch (optionChoice)
            {
                case "1":
                    // Write new content for a journal.
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
                    // Write a venting journal entry that does not need 
                    // to be saved.
                    Journal.Vent();
                    break;

                case "6":
                    // Quit the application.
                    break;

                default:
                    // Print if they pick an invalid number.
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}