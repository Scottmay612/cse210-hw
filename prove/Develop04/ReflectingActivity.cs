public class ReflectingActivity : Activity {
    private List<string> _prompts = new List<string>(){
        // Declare a list of prompts for the user.
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _promptQuestions = new List<string>(){
        // Declare a list of potential questions to ask about the prompt.
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    public ReflectingActivity() 
    {
        // Save activity name, opening message, description, and ending message 
        // in the constructor.
        _ActivityName = "Reflecting Activity";
        _OpeningMsg = $"Welcome to the {_ActivityName}!";
        _Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _ClosingMsg = $"You have completed the {_ActivityName}! The activity lasted {_Duration} seconds.";
    }
    public string RandomPromptGenerator()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        return _prompts[randomIndex];
    }
    public string RandomPrompt2Generator()
    {
        Random random = new Random();
        int randomIndex = random.Next(_promptQuestions.Count);
        return _promptQuestions[randomIndex];
    }
    public void DoReflectingActivity()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(int.Parse(_Duration));

        DateTime currentTime = DateTime.Now;

        while (currentTime < futureTime)
        {
            Console.Write($"> {RandomPrompt2Generator()} ");
            DisplaySpinner(7);
            Console.WriteLine();

            currentTime = DateTime.Now;
        }
    }
}