public class BreathingActivity : Activity {
    public BreathingActivity() {
        // Save activity name, opening message, description, and ending message 
        // in the constructor.
        _ActivityName = "Breathing Activity";
        _OpeningMsg = $"Welcome to the {_ActivityName}!";
        _Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _ClosingMsg = $"You have completed the {_ActivityName}! The activity lasted {_Duration} seconds.";
    }
    public void BreatheInCountdown()
    {
        // Display breathe in and breathe out messages to the user with a timer.

        // Set future time by adding the duration to current time.
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(int.Parse(_Duration));
        DateTime currentTime = DateTime.Now;

        // Continue displaying the messages until the time runs out.
        while (currentTime < futureTime)
        {
            Console.Write("Breathe in...");
            DisplayCountdown(4);

            Console.WriteLine();
            Console.Write("Breathe out...");
            DisplayCountdown(6);
            Console.WriteLine("\n");

            // Update the current time.
            currentTime = DateTime.Now;
        }
    }
}