
class ChecklistGoal : Goal {
    // Declare ChecklistGoal specific member variables.
    private int _repsRequired;
    private float _bonusPoints;

    // Set _repsCompleted to 0 because it is not controlled by the user.
    private int _repsCompleted = 0;
    public ChecklistGoal(){
        // Hard code the goaltype for saving and loading.
        _goalType = "checklist";
    }
    public ChecklistGoal(string[] parts) {
        // Constructor will be used to recreate the goals from a loaded file.
        _goalType = parts[0];
        _name = parts[1];
        _description = parts[2];
        _pointsAwarded = float.Parse(parts[3]);
        _bonusPoints = float.Parse(parts[4]);
        _repsRequired = int.Parse(parts[5]);
        _repsCompleted = int.Parse(parts[6]);
    }
    public override void PromptUser()
    // Prompt the user for additional goal information: repetitions required and bonus points.
    {
        base.PromptUser();

        // Prompt for repetitions required.
        Console.Write("How many times would you like to accomplish this goal? ");
        _repsRequired = int.Parse(Console.ReadLine());

        // Prompt for bonus points amount. 
        Console.Write("How many points will be awarded after the goal is fully accomplished? ");
        _bonusPoints = float.Parse(Console.ReadLine());
    }
    public override void DisplayGoal() 
    // Display additional information with the goal: repetitions completed and repetitions required.
    {
        // Add an X if the required reps are completed.
        if(_repsCompleted == _repsRequired) {
            Console.Write("[X]");
        }
        else {
            Console.Write("[ ]");
        }
        Console.Write($" {_name} ({_description}) -- Currently completed: {_repsCompleted}/{_repsRequired}");
    }
    public override void RecordEvent()
    // Record that the user finished their goal.
    {
        // Calculate how many more repetitions are required to complete the goal.
        int difference = _repsRequired - _repsCompleted;

        // Goal not done:
        if(difference > 1) {

            // Display good job and increment their reps completed by 1.
            Console.WriteLine($"Great job! You earned {_pointsAwarded} points.");
            _repsCompleted ++;
        }
        // Goal now complete:
        else if(difference == 1) {

            // Display good job and increment their reps completed by 1.
            Console.WriteLine("Great job! You've completed this checklist goal!");
            Console.WriteLine($"You earned {_pointsAwarded + _bonusPoints} points.");
            _repsCompleted ++;

            // Change the _isComplete member variable to true.
            _isComplete = true;
        }
        // Goal already complete:
        else {
            Console.WriteLine("You have already completed this goal.");
        }
    }
    public override float GetPoints()
    // Return the points awarded for completing their goal.
    {
        // Calculate how many more repetitions are required to complete the goal.
        int difference = _repsRequired - _repsCompleted;

        // Goal not complete:
        if(difference > 1) {
            return _pointsAwarded;
        }
        // Goal now complete:
        else if(difference == 1) {
            return _bonusPoints + _pointsAwarded;
        }
        // Goal already complete.
        else {
            return 0;
        }
    }
    public override string ToString() 
    // Override base class function to save additional information in the string: Bonus 
    // points, repetitions required, repetitions completed, and completion status.
    {
        string getString = $"{_goalType}|{_name}|{_description}|{_pointsAwarded}|{_bonusPoints}|{_repsRequired}|{_repsCompleted}";
        return getString;
    }
}