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
        Console.WriteLine(_OpeningMsg);
    }
    public void DisplayClosingMsg()
    {
        Console.WriteLine(_ClosingMsg);
    }
    public void DisplaySpinner(int time)
    {
        int count = 0;

        while (count <= time)
        {
            Console.Write("|");
            Thread.Sleep(300);
            Console.Write("\b \b"); // Erase the + character
            Console.Write("/"); // Replace it with the - character

            Thread.Sleep(300);
            Console.Write("\b \b"); // Erase the + character
            Console.Write("-"); // Replace it with the - character

            Thread.Sleep(300);
            Console.Write("\b \b"); // Erase the + character
            Console.Write("\\"); // Replace it with the - character

            Thread.Sleep(300);
            Console.Write("\b \b"); // Erase the + character
            count += 1;
        }
    }
    public void DisplayCountdown(int time)
    {
        while (time > 0)
        {
            Console.Write($"{time}");
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the + character
            time -= 1;
        }
    }
    public void UpdateClosingMsg()
    {
        _ClosingMsg = $"You have completed the {_ActivityName}! The activity lasted {_Duration} seconds.";
    }
}