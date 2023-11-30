public class PhaseTen : Game {
    public PhaseTen() {
        _name = "Phase 10";
        _description = "Phase 10 is a rummy-style card game where players race to complete ten unique phases, or sets of cards, to win.";
        _roundNum = 1;
        _endingLimit = 10;
    }
    public PhaseTen(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {}

    public List<string> _phases = new List<string>() {
        // Store all of the phases for the game.
        "Begin Phase 1: 2 sets of 3",
        "Begin Phase 2: 1 set of 3 + 1 run of 4",
        "Begin Phase 3: 1 set of 4 + 1 run of 4",
        "Begin Phase 4: 1 run of 7",
        "Begin Phase 5: 1 run of 8",
        "Begin Phase 6: 1 run of 9",
        "Begin Phase 7: 2 sets of 4",
        "Begin Phase 8: 7 cards of one color",
        "Begin Phase 9: 1 set of 5 + 1 set of 2",
        "Begin Phase 10: 1 set of 5 + 1 set of 3"
    };
    public override void DisplayRoundMsg()
    {
        // Display the rules for each phase (round).
        Console.WriteLine(_phases[_roundNum - 1]);
    }
}