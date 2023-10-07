using System.IO;
using System.Collections.Generic;
public class Journal
{
    // Create list of entries.
    public List<Entry> _entries = new List<Entry>();
    public void Write()
    {
        // Create a new entry.
        Entry entry1 = new Entry();

        // Get prompt from the prompt generator in Class Entry.
        string prompt = Entry.PromptGenerator(Entry._prompts);

        // Display the prompt to the user.
        Entry.DisplayPrompt(prompt);
        
        // Save users response.
        string response = Console.ReadLine();

        // Save each part of the entry and create.
        entry1._date = DateTime.Now.ToString("yyyy-MM-dd");
        entry1._response = response;
        entry1._question = prompt;

        // Save the journal entry into a single string.
        entry1._fullLine = $"Date: {entry1._date} - Prompt: " +
                           $"{entry1._question}\n{entry1._response}";

        // Add journal entry to the entries list.
        _entries.Add(entry1);
    }
    public void LoadJournal()
    {
        // Prompt user for a filename and save it to filename variable.
        Console.Write("Filename of journal: ");
        string filename = Console.ReadLine();

        // Create list of lines.
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            // Load the file and create a string for it to be displayed.
            Entry entry = new Entry();
            string[] parts = line.Split("|");
            entry._date = parts[0];
            entry._question = parts[1];
            entry._response = parts[2];
            entry._fullLine = $"Date: {entry._date} - Prompt: " +
                              $"{entry._question}\n{entry._response}";

            // Add entry to entries list.
            _entries.Add(entry);
        }
    }
    public void SaveJournal() {
        // Propt user for filename.
        Console.Write("Filename to save it to: ");
        string filename = Console.ReadLine();

        // Save entry information to file one line at a time.
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries) {
                outputFile.WriteLine($"{entry._date}|{entry._question}|{entry._response}");
            }
        }
    }
    public void DisplayJournal()
    {
        // Display the previously written entries back to the user.
        foreach (Entry entry in _entries) {
            Console.WriteLine(entry._fullLine);
            Console.WriteLine();
        }
    }
    public static void Vent()
    {
    // Write a venting journal entry that does not need 
    // to be saved.

    // Declare variables for use.
    string userVent;
    string ventChoice;

    // Print vent journal message to user and prompt them to write.
    Console.WriteLine("Welcome to the venting journal!");
    Console.WriteLine("This is a place to get thoughts, feelings, and frustrations out without saving them in your actual journal.");
    Console.WriteLine("What is on your mind? ");

    // Save response in userVent variable.
    userVent = Console.ReadLine();

    // Ask the user if they want to read what they wrote.
    Console.Write("Would you like to read what you wrote? (y/n) ");
    ventChoice = Console.ReadLine();
    if (ventChoice == "y")
    {
        // Display their response.
        Console.WriteLine();
        Console.WriteLine("Here it is! ");
        Console.WriteLine(userVent);
    }
    // Thank the user and end.
    Console.WriteLine();
    Console.WriteLine("Thank you for using the venting journal!");
    Console.WriteLine("Have a good day!:)");
    }
}