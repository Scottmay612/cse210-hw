public class EternalGoal : Goal {
    // public EternalGoal(string name, string description, float pointsAmount) : base(name, description, pointsAmount)
    //     {}
    public override void RecordEvent()
    {
        Console.WriteLine("Good job! Eternal goals can never be complete. ");
        _totalPoints += _pointsAwarded;
    }
}