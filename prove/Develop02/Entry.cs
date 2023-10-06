using System.Security.Cryptography;

public class Entry
{
    public string _date;
    public string _question;
    public string _response;
    public string _fullLine;
    public List<string> _listEntries = new List<string>();

    public static List<string> _prompts = new List<string>()
    {
        "What is one thing I'm grateful for today?",
        "What is one thing that I learned today?",
        "Who did I meet today?",
        "What did I do today that I am proud of?",
        "What was the funniest part of today?",
        "If I could do today over again, what would I do differently?",
    };
    public static int NumberGenerator()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 6);
        return randomNumber;
    }
    public static string PromptGenerator(List<string> prompts)
    {
        int randomNumber = NumberGenerator();
        string prompt = prompts[randomNumber];
        return prompt;
    }
    public static void DisplayPrompt(string prompt)
    {
        Console.WriteLine(prompt);
    }
}






















    // public static string WriteNewEntry()
    // {
    //     // Journal journal1 = new Journal();
    //     string prompt = PromptGenerator(_prompts);
    //     DisplayPrompt(prompt);

    //     Entry entry1 = new Entry();
    //     entry1._date = DateTime.Now.ToString("yyyy-MM-dd");
    //     entry1._response = Console.ReadLine();
    //     entry1._question = prompt;

    //     // Console.WriteLine("What is the name of the file? ");
    //     // // Journal journal1 = new Journal();
    //     // // journal1._filename = Console.ReadLine();
    //     // string filename = Console.ReadLine();
    //     // journal1._filename = filename;

    //     // Append the new entry to the file.
    //     // using (StreamWriter outputFile = new StreamWriter(journal1._filename, true))
    //     // {
    //     //     outputFile.WriteLine($"{entry1._date}~{entry1._question}~{entry1._response}");
    //     // }
    //     return journal1._filename;
    // }