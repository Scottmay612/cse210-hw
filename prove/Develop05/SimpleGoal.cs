public class SimpleGoal : Goal {
    public SimpleGoal(){
        // Hard code the goaltype for saving and loading.
        _goalType = "simple";
    }
    public SimpleGoal(string[] parts) {
        // Constructor will be used to recreate the goals from a loaded file.
        _goalType = parts[0];
        _name = parts[1];
        _description = parts[2];
        _pointsAwarded = float.Parse(parts[3]);
        _isComplete = bool.Parse(parts[4]);
    }

    public override void RecordEvent()
    // Display congrats and save the goal as complete.
    {
        Console.WriteLine($"Good job! You earned {_pointsAwarded} points.");
        _isComplete = true;
    }
    public override string ToString()
    // Change the goal to a string for saving to a file.
    // Return the goal string.
    {
        string getString = $"{_goalType}|{_name}|{_description}|{_pointsAwarded}|{_isComplete}";
        return getString;
    }
}