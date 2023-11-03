public class Activity {
    private string _openingMsg;
    public string _OpeningMsg   // property
    {
        get { return _openingMsg; }   // get method
        set { _openingMsg = value; }  // set method
    }
    private string _closingMsg;
    public string _ClosingMsg   // property
    {
        get { return _closingMsg; }   // get method
        set { _closingMsg = value; }  // set method
    }
    private string _description;
    public string _Description   // property
    {
        get { return _description; }   // get method
        set { _description = value; }  // set method
    }
    private string _duration;
    public string _Duration   // property
    {
        get { return _duration; }   // get method
        set { _duration = value; }  // set method
    }
    private string _activityName;
    public string _ActivityName   // property
    {
        get { return _activityName; }   // get method
        set { _activityName = value; }  // set method
    }
    public void DisplayOpeningMsg()
    {
        // Display opening message.
        Console.WriteLine(_OpeningMsg);
    }
    public void DisplayClosingMsg()
    {
        // Display closing message.
        Console.WriteLine(_ClosingMsg);
    }
    public void DisplaySpinner(int time)
    {
        // Display a spinner to prompt the user to wait.
        // Parameter: Amount of seconds for the timer to go.
        int count = 0;

        while (count <= time)
        {
            // Loop until the count limit exceeds the time.

            Console.Write("|");
            Thread.Sleep(300);
            Console.Write("\b \b"); // Erase the | character
            Console.Write("/"); // Replace it with the / character

            Thread.Sleep(300);
            Console.Write("\b \b"); // Erase the / character
            Console.Write("-"); // Replace it with the - character

            Thread.Sleep(300);
            Console.Write("\b \b"); // Erase the - character
            Console.Write("\\"); // Replace it with the \ character

            Thread.Sleep(300);
            Console.Write("\b \b"); // Erase the \ character
            count += 1;
        }
    }
    public void DisplayCountdown(int time)
    {
        // Displays countdown from a given time.
        // Parameter: Number of seconds for countdown timer.

        while (time > 0)
        {
            // Continue until the time exceeds the limit.

            // Display number.
            Console.Write($"{time}");

            // Wait for one second between each number.
            Thread.Sleep(1000);

            // Erase the previous number.
            Console.Write("\b \b"); 

            // Decrement time by 1.
            time -= 1;
        }
    }
    public void UpdateClosingMsg()
    {
        // Update the closing message in the constructor.
        _ClosingMsg = $"You have completed the {_ActivityName}! The activity lasted {_Duration} seconds.";
    }
}