class ChecklistGoal : Goal {
    private int _repsRequired;
    private float _bonusPoints;
    private int _repsCompleted = 0;
    public ChecklistGoal(){
    }
    public override void PromptUser()
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
    {
        base.DisplayGoal();
        Console.Write($" -- Currently completed: {_repsCompleted}/{_repsRequired}");
    }
    public override void RecordEvent()
    {
        int difference = _repsRequired - _repsCompleted;
        if(difference > 1){
            Console.WriteLine("Great job!");
            _repsCompleted ++;
            _totalPoints += _pointsAwarded;
        }
        else if(difference == 1) {
            Console.WriteLine("Great job! You've completed this checklist goal!");
            _totalPoints += _pointsAwarded + _bonusPoints;
            _repsCompleted ++;
            _isComplete = true;
        }
        else {
            Console.WriteLine("You have already completed this goal.");
        }
    }
    public override string GetStringRepresentation() {
        string getString = $"{_name}|{_description}|{_pointsAwarded}|{_bonusPoints}|{_repsRequired}";
        return getString;
    }
}