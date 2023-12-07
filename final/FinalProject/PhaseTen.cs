public class PhaseTen : Game {
    public PhaseTen() {
        _name = "Phase 10";
        _description = "Phase 10 is a rummy-style card game where players race to complete ten unique phases, or sets of cards, to win.";
        _roundNum = 1;
        _endingLimit = 10;
        _gameRules = new List<string>() {
            "Players: Phase Ten can be played with 2-6 players.",
            "Each round: Each round has its own phase. Players will take turn drawing cards from the deck to try and create that phase. If they like that card, they must swap it for one of their current cards.",
            "Playing your cards: When players have all the correct cards, they can lay them down. Then they must continue playing until they have added all their remaining cards to any of the played cards on the table.",
            "Round end: Once a player has played all of their cards, the round is over. Whoever has passed the phase can move on to the next one. If they did not pass, they must do the phase over again.",
            "Game end: The first person to finish the 10th phase wins. If two people are both on phase 10 together, the first person to get rid of all their cards is the winner."
        };
    }
        // Create a constructor for when a game is loaded back in.
    public PhaseTen(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {
            _gameRules = new List<string>() {
            "Players: Phase Ten can be played with 2-6 players.",
            "Each round: Each round has its own phase. Players will take turn drawing cards from the deck to try and create that phase. If they like that card, they must swap it for one of their current cards.",
            "Playing your cards: When players have all the correct cards, they can lay them down. Then they must continue playing until they have added all their remaining cards to any of the played cards on the table.",
            "Round end: Once a player has played all of their cards, the round is over. Whoever has passed the phase can move on to the next one. If they did not pass, they must do the phase over again.",
            "Game end: The first person to finish the 10th phase wins. If two people are both on phase 10 together, the first person to get rid of all their cards is the winner."
        };
    }
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
    public override void GetScores()
    {
        foreach(Player player in _players) {
            Console.Write($"Did {player.GetName()} finish this phase? (y/n) ");
            string didPass = Console.ReadLine();
            if(didPass == "y") {
                player.SetScore(1);
            }
        }
    }
}
