
public class SkullKing : Game {
    public SkullKing() {
        _name = "Skull King";
        _description = "The game lasts ten rounds, and in each round, each player is dealt as many cards as the number of the round. Try to get as many points as you can!";
        _roundNum = 1;
        _endingLimit = 10;
        _gameRules = new List<string>() {
            "Gather your players: Skull King can be played with 2-6 players.",
            "Deal cards equal to the round number (1 card in round 1, 2 cards in round 2, etc.)",
            "Bid: Guess how many tricks you'll win like a true fortune teller.",
            "Play cards, following suit if possible (except with special cards).",
            "Highest card wins the trick! (Remember, highest numbered card of the suit led, not just any big number.)",
            "Score points: Earn points for each trick you win according to your bid, plus bonus loot for capturing special cards.",
            "Game end: After 10 rounds, the game is over. Total all points to find the winner! "
        };
    }
    public SkullKing(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {
        _gameRules = new List<string>() {
            "Gather your players: Skull King can be played with 2-6 players.",
            "Deal cards equal to the round number (1 card in round 1, 2 cards in round 2, etc.)",
            "Bid: Guess how many tricks you'll win like a true fortune teller.",
            "Play cards, following suit if possible (except with special cards).",
            "Highest card wins the trick! (Remember, highest numbered card of the suit led, not just any big number.)",
            "Score points: Earn points for each trick you win according to your bid, plus bonus loot for capturing special cards.",
            "Game end: After 10 rounds, the game is over. Total all points to find the winner! "
        };
    }
    private List<string> _cardValues = new List<string>() {
        "Color cards: Colored cards are of least value. Each color has cards numbered 1-14. 14 is worth the most and 1 is worth the least.",
        "Escape: These five cards have a special purpose - avoiding victory. They lose to all other cards, making them valuable tools for ensuring you don't take more tricks than your bid.",
        "Pirate: Pirate cards are stronger than all other cards. However, they are all equal to each other. The first pirate played will defeat all other pirates in the trick.",
        "Tigress: Tigress is a special pirate. When you play this card, you decide whethere she will be played as a pirate or as an escape card.",
        "Skull King: The Skull King is the strongest card. He defeats almost all other cards. The only cards that can beat him are the mermaids.",
        "Mermaids: Mermaids can beat every other card except for the pirates. There are only two mermaids in the deck. If both are played in the same trick, then the first player to play one wins the trick whether they want to or not!"
    };

    public override List<Player> OrderPlayers()
    {
        List<Player> sortedList = _players.OrderByDescending(o=>o.GetPoints()).ToList();
        return sortedList;
    }
    public override string ShowInGameMenu(string menuChoice, int roundLimit)
    {
        while (menuChoice == "1" || menuChoice == "2") {
            Console.Clear();
            Console.WriteLine("Here are your menu options: ");
            Console.WriteLine("1. View Game Rules");
            Console.WriteLine("2. See Card Values");
            Console.WriteLine("3. Save Game");
            Console.WriteLine("4. Return to Game");
            Console.WriteLine("5. Quit Game");
            Console.Write("What would you like to do? ");
            menuChoice = Console.ReadLine();
            switch (menuChoice) {
                case "1": {
                    Console.Clear();
                    Console.WriteLine($"{_name} rules: ");
                    DisplayRules();
                    Console.Write("Press enter to continue: ");
                    Console.ReadLine();
                    break;
                }
                case "2": {
                    Console.Clear();
                    Console.WriteLine("Card values: ");
                    DisplayCardValues();
                    Console.Write("Press enter to continue: ");
                    Console.ReadLine();
                    break;
                }
                case "3": {
                    Console.Write("What is the file name? ");
                    string fileName = Console.ReadLine();
                    SaveScores(fileName, GetScoreStrings(_players));
                    break;
                }
                case "4": {
                    break;
                }
                case "5": {
                    _roundNum = roundLimit + 1;
                    break;
                }
            }
        }
        return menuChoice;
    }
    public override void DisplayRoundMsg()
    {
        base.DisplayRoundMsg();
        Console.WriteLine($"This round, everyone will have {_roundNum} card(s).");
    }
    public void DisplayCardValues() {
        foreach(string value in _cardValues) {
            Console.WriteLine($"- {value}");
        }
    }
    public override void RunGame(int roundLimit) 
    {
        // Declare the user's response for whether they would like to pause the game or continue playing.
        string continueResponse = "";
        string menuChoice = "1";

        // Continue looping while their are rounds remaining and the user has not typed save.
        while(_roundNum <= roundLimit && menuChoice != "3" && menuChoice != "5") {

            // Display round number.
            Console.Clear();
            DisplayRoundMsg();
            Console.WriteLine();

            // Get the round scores for each player.
            GetScores();

            // Display the current leaderboard.
            Console.WriteLine();
            Console.WriteLine("Here is the current leaderboard:");
            DisplayLeaderBoard();

            // Give the user the option to either continue or pause the game and save their scores.
            Console.Write("Press enter to continue or type 'menu' for more options: ");
            continueResponse = Console.ReadLine();

            // Increment the round number by one prior to saving the file.
            _roundNum ++;

            // Get the filename. Write the round number and the player's name/scores to the file.
            if(continueResponse.ToLower() == "menu") {
                menuChoice = ShowInGameMenu(menuChoice, roundLimit);
            }
        // Give different ending messages depending on whether the user finished the game or paused it.
        Console.WriteLine();
        }
        if(menuChoice == "3") {
            // Display confirmation saved message.
            Console.WriteLine("Your progress is saved. Come again soon!");
        }
        else {
            // If the game is finished, display the final scores.
            Console.WriteLine("The final leaderboard is...");

            // Pause for a moment for dramatic effect.
            Thread.Sleep(1000);

            // Display the scores.
            DisplayLeaderBoard();

            Console.Write("Would you like to save your scores? (y/n) ");
            string saveResponse = Console.ReadLine();

            if (saveResponse == "y") {
                Console.Write("What is the file name? ");
                string gameFileFinished = Console.ReadLine();
                SaveScores(gameFileFinished, GetScoreStrings(_players));
            }
        }
    }
}