public class PhaseTen : Game {
    public PhaseTen() {
        _name = "Phase 10";
        _description = "Phase 10 is a rummy-style card game where players race to complete ten unique phases, or sets of cards, to win.";
        _roundNum = 1;
        _endingLimit = 10;
    }
        // Create a constructor for when a game is loaded back in.
    public PhaseTen(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {}

    public List<string> _phases = new List<string>() {
        // Store all of the phases for the game.
        "2 sets of 3",
        "1 set of 3 + 1 run of 4",
        "1 set of 4 + 1 run of 4",
        "1 run of 7",
        "1 run of 8",
        "1 run of 9",
        "2 sets of 4",
        "7 cards of one color",
        "1 set of 5 + 1 set of 2",
        "1 set of 5 + 1 set of 3"
    };
    public override void DisplayRoundMsg()
    {
        // Display the rules for each phase (round).
        Console.WriteLine($"Begin Phase {_roundNum}: {_phases[_roundNum - 1]}");
    }
}