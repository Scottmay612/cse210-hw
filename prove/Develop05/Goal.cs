public abstract class Goal {
    protected string _name;
    protected string _description;
    protected float _pointsAwarded;
    protected float _totalPoints = 0;
    protected bool _isComplete = false;
    public Goal()
    {

    }
    public void DisplayPoints() {
        Console.WriteLine($"You have {_totalPoints} points!");
    }

    public virtual void PromptUser() {
        // Prompt for goal name
        Console.Write("What is the name of the goal? ");
        _name = Console.ReadLine();

        // Prompt for goal desc
        Console.Write("What is a description of the goal? ");
        _description = Console.ReadLine();

        // Prompt for points amount.
        Console.Write("How many points will be rewarded for accomplishing this goal? ");
        _pointsAwarded = float.Parse(Console.ReadLine());
    }
    public virtual void DisplayGoal() {
        if(_isComplete) {
            Console.Write("[X]");
        }
        else {
            Console.Write("[ ]");
        }
        Console.Write($" {_name} ({_description})");
    }
    public abstract void RecordEvent();
    public virtual string GetStringRepresentation() {
        string getString = $"{_name}|{_description}|{_pointsAwarded}";
        return getString;
    }
    
    public virtual void SaveGoal(string filename) {
        using (StreamWriter outputFile = new StreamWriter(filename)) {
            outputFile.WriteLine(GetStringRepresentation());
        }
    }
    public void testWrite(string filename) {
        using (StreamWriter outputFile = new StreamWriter(filename)) {
            outputFile.WriteLine("Hello");
        }
    }
}