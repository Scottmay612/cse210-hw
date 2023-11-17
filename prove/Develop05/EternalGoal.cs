public class EternalGoal : Goal {
    public EternalGoal()
    {
        // Hard code the goaltype for saving and loading.
        _goalType = "eternal";
    }
    public EternalGoal(string[] parts) {
        // Constructor will be used to recreate the goals loaded from a file.
        _goalType = parts[0];
        _name = parts[1];
        _description = parts[2];
        _pointsAwarded = float.Parse(parts[3]);
    }
    public override void RecordEvent()
    {
        // Eternal Goals are never marked complete. The program will only say good job.
        Console.WriteLine($"Good job! You earned {_pointsAwarded} points.");
        Console.WriteLine($"Eternal goals are never marked complete.");
    }
}