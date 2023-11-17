public abstract class Goal {
    // Declare all member variables for base class.
    protected string _goalType;
    protected string _name;
    protected string _description;
    protected float _pointsAwarded;
    protected bool _isComplete = false;
    public virtual void PromptUser() {
        // Get the goal name, description, and points amount from user.

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
        // Display the goal with an [X] if it is finished and with [ ] if it is not.

        if(_isComplete) {
            Console.Write("[X]");
        }
        else {
            Console.Write("[ ]");
        }
        Console.Write($" {_name} ({_description})");
    }
    // Declare abstract method to record if the user did their goal.
    public abstract void RecordEvent();

    // Declare abstract method to return the points the user receives for completing their goal.
    public virtual float GetPoints() {
    // Return the points awarded for finishing their goal.
        return _pointsAwarded;
    }

    public override string ToString()
    // Change the goal to a string for saving to a file.
    // Return the goal string.
    {
        string getString = $"{_goalType}|{_name}|{_description}|{_pointsAwarded}";
        return getString;
    }
}