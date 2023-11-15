public class SimpleGoal : Goal {
    // public SimpleGoal(){}

    public override void RecordEvent()
    {
        Console.WriteLine("Good job!");
        _isComplete = true;
        _totalPoints += _pointsAwarded;
    }
}