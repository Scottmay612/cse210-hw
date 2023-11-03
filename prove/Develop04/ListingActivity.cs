public class ListingActivity : Activity {
    private List<string> _prompts = new List<string>() {
        // Save potential prompts as a list of strings.
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    // Create a list of strings for user responses.
    private List<string> responses = new List<string>() {};

    public ListingActivity()
    {
        // Save activity name, opening message, description, and ending message 
        // in the constructor.
        _ActivityName = "Listing Activity";
        _OpeningMsg = "Welcome to the Listing Activity!";
        _Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _ClosingMsg = $"You have completed the {_ActivityName}! The activity lasted {_Duration} seconds.";
    }
    public string RandomPromptGenerator()
    {
        // Pick a random prompt from the list of prompts and return it.
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);

        // Return random prompt.
        return _prompts[randomIndex];
    }
    public void DoListingActivity() {

        // Set future time by adding the duration to current time.
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(int.Parse(_Duration));
        DateTime currentTime = DateTime.Now;
        
        // Declare count. This will be counting how many respones they make in 
        // the loop.
        int count = 0;

        // Continue looping until the time runs out.
        while (currentTime < futureTime) {
            // Get user response.
            Console.Write("> ");
            string response = Console.ReadLine();

            // Add their response to the list of responses.
            responses.Add(response);

            // Add a count for the response.
            count += 1;

            // Update the current time.
            currentTime = DateTime.Now;
        }
        // Display the number of responses from the user.
        Console.WriteLine($"Good job! You entered {count} response(s).");
    }
    public void ReadResponses() {
        // Read the user's responses back to them.

        // Declare first number for numbered list.
        int responseNumber = 1;

        // Display all of the responses in a numbered list.
        for (int i = 0; i < responses.Count; i++) {
            // Add a pause between responses.
            Thread.Sleep(500);
            Console.WriteLine($"{responseNumber}. {responses[i]}");
            // Console.WriteLine();

            // Increment the response number by one.
            responseNumber += 1;
        }
        // Pause after all the responses have been displayed.
        Thread.Sleep(1000);
        
        string finishListing = " ";

        // Don't continue until the user presses enter.
        while (finishListing != "") {
            Console.WriteLine("Press enter when you are ready to continue. ");
            finishListing = Console.ReadLine();
        }
    }
}