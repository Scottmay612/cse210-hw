public class FiveCrowns : Game {

    // Constructor for when the game is initally created.
    public FiveCrowns() {
        _name = "Five Crowns";
        _description = "For this game, you want to end with the least amount of points as possible. Each round, you will try to discard all of your cards by putting them in melds (runs or books). Each round ends after the first person lays down all of their cards. Any cards remaining will be counted as your score.";
        _roundNum = 3;
        _endingLimit = 13;

        // Game rules for the in-game menu.
        _gameRules = new List<string>() {
            "Gather your players: Five Crowns can be played with 1-7 people.",
            "Game setup: For the first round, each player gets 3 cards. The next round is 4. Then, 5. All the way to 13.",
            "Each round: Each player will take turns drawing a card from the deck. If they want to keep it, they must trade it out for one of their current cards.",
            "Wilds: Jokers are wild as well as whatever number matches how many cards each player has. If each player has 5 cards, then all 5's are wild.",
            "Round end: The round ends when a player is able to group all of their cards into sets or runs of at least 3 cards. After someone lays their cards, each player has one more turn before the round is over.",
            "Scoring: At the end of each round, each player's remaining cards are added to their score.",
            "Game end: The game ends after the 13th round. The player with the least amount of points wins!",
        };

        // Suggestions for the in-game menu.
        _suggestions = new List<string>() {
            "Order your cards in ascending order at the beginning of each round to keep your hand clean and easy to see.",
            "Pay attention to the round number! The wild card changes with each round and it is very easy to accidentally discard one.",
            "When the round is drawing to a close, get rid of any high cards that you still have.",
            "Pay attention to which cards the person after you is picking up. If you keep giving them the cards they want, they make go out quickly!"
        };
    }

    // Constructor for when the game is recreated and scores are loaded back in.
    public FiveCrowns(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {
        
        // Game rules for the in-game menu.
        _gameRules = new List<string>() {
            "Gather your players: Five Crowns can be played with 1-7 people.",
            "Game setup: For the first round, each player gets 3 cards. The next round is 4. Then, 5. All the way to 13.",
            "Each round: Each player will take turns drawing a card from the deck. If they want to keep it, they must trade it out for one of their current cards.",
            "Wilds: Jokers are wild as well as whatever number matches how many cards each player has. If each player has 5 cards, then all 5's are wild.",
            "Round end: The round ends when a player is able to group all of their cards into sets or runs of at least 3 cards. After someone lays their cards, each player has one more turn before the round is over.",
            "Scoring: At the end of each round, each player's remaining cards are added to their score.",
            "Game end: The game ends after the 13th round. The player with the least amount of points wins!",
        };

        // Suggestions for the in-game menu.
        _suggestions = new List<string>() {
            "Order your cards in ascending order at the beginning of each round to keep your hand clean and easy to see.",
            "Pay attention to the round number! The wild card changes with each round and it is very easy to accidentally discard one.",
            "When the round is drawing to a close, get rid of any high cards that you still have.",
            "Pay attention to which cards the person after you is picking up. If you keep giving them the cards they want, they make go out quickly!"
        };
    }
    private void DisplayWildCard(){
    // This function displays the wild card based on the current round number.

        // Check the current round number.
        if (_roundNum <= 10) {

            // For rounds 1-10, the round number is the wild card number.
            Console.WriteLine($"Wild Card: {_roundNum}");
        }
        else if (_roundNum == 11) {

            // At round 11, the wild cards are jacks.
            Console.WriteLine($"Wild Card: Jack");
        }
        else if (_roundNum == 12) {

            // At round 12, the wild cards are queens.
            Console.WriteLine($"Wild Card: Queen");
        }
        else if (_roundNum == 13) {

            // At round 13, the wild cards are kings.
            Console.WriteLine($"Wild Card: King");
        }
    }
    public override void DisplayRoundMsg()
    {
        // Display the normal round number. 
        base.DisplayRoundMsg();

        // Tell how many cards everyone will have.
        Console.WriteLine($"This round, everyone will have {_roundNum} cards.");

        // Tell which card is the wildcard.
        DisplayWildCard();
    }
}