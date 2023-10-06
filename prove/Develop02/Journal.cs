using System.IO;
using System.Collections.Generic;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void Write()
    {
        Entry entry1 = new Entry();
        string prompt = Entry.PromptGenerator(Entry._prompts);
        Entry.DisplayPrompt(prompt);
        
        string response = Console.ReadLine();

        entry1._date = DateTime.Now.ToString("yyyy-MM-dd");
        entry1._response = response;
        entry1._question = prompt;
        entry1._fullLine = $"Date: {entry1._date} - Prompt: {entry1._question}\n{entry1._response}";

        _entries.Add(entry1);
    }
    public void LoadJournal()
    {
        Console.Write("Filename of journal: ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = new Entry();
            string[] parts = line.Split("|");
            entry._date = parts[0];
            entry._question = parts[1];
            entry._response = parts[2];
            entry._fullLine = $"Date: {entry._date} - Prompt: {entry._question}\n{entry._response}";
            _entries.Add(entry);
        }
    }
    public void SaveJournal() {
        Console.Write("Filename to save it to: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries) {
                outputFile.WriteLine($"{entry._date}|{entry._question}|{entry._response}");
            }
        }
    }
    public void DisplayJournal()
    {
        foreach (Entry entry in _entries) {
            Console.WriteLine(entry._fullLine);
            Console.WriteLine();
        }
    }
}