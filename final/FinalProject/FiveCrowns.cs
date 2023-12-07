public class FiveCrowns : Game {
    public FiveCrowns() {
        _name = "Five Crowns";
        _description = "For this game, you want to end with the least amount of points as possible. Each round, you will try to discard all of your cards by putting them in melds (runs or books). Each round ends after the first person lays down all of their cards. Any cards remaining will be counted as your score.";
        _roundNum = 3;
        _endingLimit = 13;
        _gameRules = new List<string>() {
            "Gather your players: Five Crowns can be played with 1-7 people.",
            "Game setup: For the first round, each player gets 3 cards. The next round is 4. Then, 5. All the way to 13.",
            "Each round: Each player will take turns drawing a card from the deck. If they want to keep it, they must trade it out for one of their current cards.",
            "Wilds: Jokers are wild as well as whatever number matches how many cards each player has. If each player has 5 cards, then all 5's are wild.",
            "Round end: The round ends when a player is able to group all of their cards into sets or runs of at least 3 cards. After someone lays their cards, each player has one more turn before the round is over.",
            "Scoring: At the end of each round, each player's remaining cards are added to their score.",
            "Game end: The game ends after the 13th round. The player with the least amount of points wins!",
        };
    }
    public FiveCrowns(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {
        _gameRules = new List<string>() {
            "Gather your players: Five Crowns can be played with 1-7 people.",
            "Game setup: For the first round, each player gets 3 cards. The next round is 4. Then, 5. All the way to 13.",
            "Each round: Each player will take turns drawing a card from the deck. If they want to keep it, they must trade it out for one of their current cards.",
            "Wilds: Jokers are wild as well as whatever number matches how many cards each player has. If each player has 5 cards, then all 5's are wild.",
            "Round end: The round ends when a player is able to group all of their cards into sets or runs of at least 3 cards. After someone lays their cards, each player has one more turn before the round is over.",
            "Scoring: At the end of each round, each player's remaining cards are added to their score.",
            "Game end: The game ends after the 13th round. The player with the least amount of points wins!",
        };
    }
    public void DisplayWildCard(){
        if (_roundNum <= 10) {
            Console.WriteLine($"Wild Card: {_roundNum}");
        }
        else if (_roundNum == 11) {
            Console.WriteLine($"Wild Card: Jack");
        }
        else if (_roundNum == 12) {
            Console.WriteLine($"Wild Card: Queen");
        }
        else if (_roundNum == 13) {
            Console.WriteLine($"Wild Card: King");
        }
    }
    public override void DisplayRoundMsg()
    {
        base.DisplayRoundMsg();
        Console.WriteLine($"This round, everyone will have {_roundNum} cards.");
        DisplayWildCard();
    }
}