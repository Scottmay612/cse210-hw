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
        // Store list of prompts that will be given to the user.
        "What is one thing I'm grateful for today?",
        "What is one thing that I learned today?",
        "Who did I meet today?",
        "What did I do today that I am proud of?",
        "What was the funniest part of today?",
        "If I could do today over again, what would I do differently?",
    };
    public static int NumberGenerator()
    {
        // Generate random number between 1 and 6.
        Random random = new Random();
        int randomNumber = random.Next(1, 6);

        // Return random number.
        return randomNumber;
    }
    public static string PromptGenerator(List<string> prompts)
    {
        // Use the random number to pick a random prompt from the list of promps.
        int randomNumber = NumberGenerator();
        string prompt = prompts[randomNumber];

        // Return the prompt.
        return prompt;
    }
    public static void DisplayPrompt(string prompt)
    {
        // Display the prompt to the user.
        Console.WriteLine(prompt);
    }

}