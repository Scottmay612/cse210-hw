
public class SkullKing : Game {
    // List of special card values for the in-game menu.
    private List<string> _cardValues = new List<string>() {
        "Color cards: Colored cards are of least value. Each color has cards numbered 1-14. 14 is worth the most and 1 is worth the least.",
        "Escape: These five cards have a special purpose - avoiding victory. They lose to all other cards, making them valuable tools for ensuring you don't take more tricks than your bid.",
        "Pirate: Pirate cards are stronger than all other cards. However, they are all equal to each other. The first pirate played will defeat all other pirates in the trick.",
        "Tigress: Tigress is a special pirate. When you play this card, you decide whethere she will be played as a pirate or as an escape card.",
        "Skull King: The Skull King is the strongest card. He defeats almost all other cards. The only cards that can beat him are the mermaids.",
        "Mermaids: Mermaids can beat every other card except for the pirates. There are only two mermaids in the deck. If both are played in the same trick, then the first player to play one wins the trick whether they want to or not!"
    };
    // Constructor for when the game is initally created.
    public SkullKing() {
        // Declare the game name, description, which round it starts on, and at what point it ends.
        _name = "Skull King";
        _description = "The game lasts ten rounds, and in each round, each player is dealt as many cards as the number of the round. Try to get as many points as you can!";
        _roundNum = 1;
        _endingLimit = 10;

        // Game rules for the in-game menu.
        _gameRules = new List<string>() {
            "Gather your players: Skull King can be played with 2-6 players.",
            "Deal cards equal to the round number (1 card in round 1, 2 cards in round 2, etc.)",
            "Bid: Guess how many tricks you'll win like a true fortune teller.",
            "Play cards, following suit if possible (except with special cards).",
            "Highest card wins the trick! (Remember, highest numbered card of the suit led, not just any big number.)",
            "Score points: Earn points for each trick you win according to your bid, plus bonus loot for capturing special cards.",
            "Game end: After 10 rounds, the game is over. Total all points to find the winner! "
        };

        // Suggestions for the in-game menu.
        _suggestions = new List<string>() {
            "Go for 0 tricks! You get 10 x the round number points if you do this. If it is possible, do it!",
            "If you win a trick towards the end of the round, you will probably keep winning. Try to only win a trick if you are okay with winning the rest of them as well.",
            "If you do not have the first color played, you can play either of the other two colors instead and it doesn't count for anything. Try to get rid of each color as quickly as you can.",
            "If you have a pirate but do not want to win the trick. Wait until someone else plays one and then play yours. The first pirate played is the only one that counts."
        };
    }
    // Constructor for when the game is recreated and scores are loaded back in.
    public SkullKing(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {
        // Game rules for the in-game menu.
        _gameRules = new List<string>() {
            "Gather your players: Skull King can be played with 2-6 players.",
            "Deal cards equal to the round number (1 card in round 1, 2 cards in round 2, etc.)",
            "Bid: Guess how many tricks you'll win like a true fortune teller.",
            "Play cards, following suit if possible (except with special cards).",
            "Highest card wins the trick! (Remember, highest numbered card of the suit led, not just any big number.)",
            "Score points: Earn points for each trick you win according to your bid, plus bonus loot for capturing special cards.",
            "Game end: After 10 rounds, the game is over. Total all points to find the winner! "
        };

        // Suggestions for the in-game menu.
        _suggestions = new List<string>() {
            "Go for 0 tricks! You get 10 x the round number points if you do this. If it is possible, do it!",
            "If you win a trick towards the end of the round, you will probably keep winning. Try to only win a trick if you are okay with winning the rest of them as well.",
            "If you do not have the first color played, you can play either of the other two colors instead and it doesn't count for anything. Try to get rid of each color as quickly as you can.",
            "If you have a pirate but do not want to win the trick. Wait until someone else plays one and then play yours. The first pirate played is the only one that counts."
        };
    }


    public override List<Player> OrderPlayers()
    {
        // Sort the players from greatest score to lowest score.
        List<Player> sortedList = _players.OrderByDescending(o=>o.GetPoints()).ToList();

        // Return the sorted list.
        return sortedList;
    }
    public override string RunInGameMenu(string menuChoice, int roundLimit)
    {
        // Force menu choice to "1" initially.
        menuChoice = "1";

        // Loop as long as the user chooses a valid option (1, 2, 3).
        while (menuChoice == "1" || menuChoice == "2" || menuChoice == "3")
        {
            // Clear the console.
            Console.Clear();

            // Display menu options.
            Console.WriteLine("Here are your menu options: ");
            Console.WriteLine("1. View Game Rules");
            Console.WriteLine("2. View Suggestions");
            Console.WriteLine("3. View Card Values");
            Console.WriteLine("4. Save Game");
            Console.WriteLine("5. Return to Game");
            Console.WriteLine("6. Quit Game");

            // Prompt user for their choice.
            Console.Write("What would you like to do? ");
            menuChoice = Console.ReadLine();

            // Switch statement to handle user input.
            switch (menuChoice)
            {
                case "1": // View game rules.
                    {
                        // Clear the console.
                        Console.Clear();

                        // Display the game rules.
                        Console.WriteLine($"{_name} rules: ");
                        DisplayRules();

                        // Wait for user input to continue.
                        Console.Write("Press enter to continue: ");
                        Console.ReadLine();
                        break;
                    }
                case "2": // View suggestions.
                    {
                        // Clear the console.
                        Console.Clear();

                        // Display suggestions.
                        DisplaySuggestions();

                        // Wait for user input to continue.
                        Console.Write("Press enter to continue: ");
                        Console.ReadLine();
                        break;
                    }
                case "3": // View card values.
                    {
                        // Clear the console.
                        Console.Clear();

                        // Display card values.
                        Console.WriteLine("Card values: ");
                        DisplayCardValues();

                        // Wait for user input to continue.
                        Console.Write("Press enter to continue: ");
                        Console.ReadLine();
                        break;
                    }
                case "4": // Save game.
                    {
                        // Prompt for filename.
                        Console.Write("What is the file name? ");
                        string fileName = Console.ReadLine();

                        // Save scores to file.
                        SaveScores(fileName, GetScoreStrings(_players));
                        break;
                    }
                case "5": // Return to game.
                    {
                        // Do nothing, continue the loop.
                        break;
                    }
                case "6": // Quit game.
                    {
                        // Set the round number to end the game.
                        _roundNum = roundLimit + 1;
                        break;
                    }
                default: // Invalid input.
                    {
                        Console.WriteLine("Please enter a valid menu response.");
                        break;
                    }
            }
        }
        // Return the user's final choice
        return menuChoice;
    }

    // public override string ShowInGameMenu(string menuChoice, int roundLimit)
    // {
    //     menuChoice = "1";
    //     while (menuChoice == "1" || menuChoice == "2" || menuChoice == "3") {
    //         Console.Clear();
    //         Console.WriteLine("Here are your menu options: ");
    //         Console.WriteLine("1. View Game Rules");
    //         Console.WriteLine("2. View Suggestions");
    //         Console.WriteLine("3. View Card Values");
    //         Console.WriteLine("4. Save Game");
    //         Console.WriteLine("5. Return to Game");
    //         Console.WriteLine("6. Quit Game");
    //         Console.Write("What would you like to do? ");
    //         menuChoice = Console.ReadLine();
    //         switch (menuChoice) {
    //             case "1": {
    //                 Console.Clear();
    //                 Console.WriteLine($"{_name} rules: ");
    //                 DisplayRules();
    //                 Console.Write("Press enter to continue: ");
    //                 Console.ReadLine();
    //                 break;
    //             }
    //             case "2": {
    //                 Console.Clear();
    //                 DisplaySuggestions();
    //                 Console.Write("Press enter to continue: ");
    //                 Console.ReadLine();
    //                 break;
    //             }
    //             case "3": {
    //                 Console.Clear();
    //                 Console.WriteLine("Card values: ");
    //                 DisplayCardValues();
    //                 Console.Write("Press enter to continue: ");
    //                 Console.ReadLine();
    //                 break;
    //             }
    //             case "4": {
    //                 Console.Write("What is the file name? ");
    //                 string fileName = Console.ReadLine();
    //                 SaveScores(fileName, GetScoreStrings(_players));
    //                 break;
    //             }
    //             case "5": {
    //                 break;
    //             }
    //             case "6": {
    //                 _roundNum = roundLimit + 1;
    //                 break;
    //             }
    //             default: {
    //                 Console.WriteLine("Please enter a valid menu response.");
    //                 break;
    //             }
    //         }
    //     }
    //     return menuChoice;
    // }
    public override void DisplayRoundMsg()
    {
        // Override DisplayRoundMsg so that it tells how many cards everyone will have.
        base.DisplayRoundMsg();
        Console.WriteLine($"This round, everyone will have {_roundNum} card(s).");
    }
    public override void RunGame(int roundLimit) 
    {
        // Declare the user's response for whether they would like to pause the game or continue playing.
        string continueResponse = "";
        string menuChoice = "1";

        // Continue looping while their are rounds remaining and the user has not typed save.
        while(_roundNum <= roundLimit && menuChoice != "4" && menuChoice != "6") {

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

            // Give the user the option to either continue or open the game menu for more options.
            Console.Write("Press enter to continue or type 'menu' for more options: ");
            continueResponse = Console.ReadLine();

            // Increment the round number by one prior to saving the file.
            _roundNum ++;

            // Get the filename. Write the round number and the player's name/scores to the file.
            if(continueResponse.ToLower() == "menu") {
                menuChoice = RunInGameMenu(menuChoice, roundLimit);
            }

        // Give different ending messages depending on whether the user finished the game or paused it.
        Console.WriteLine();
        }
        if(menuChoice == "4") {
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

            // Ask if they would like to save their final scores.
            Console.Write("Would you like to save your scores? (y/n) ");
            string saveResponse = Console.ReadLine();

            if (saveResponse == "y") {
                // If they want to save their final scores, prompt for the file name.
                Console.Write("What is the file name? ");
                string gameFileFinished = Console.ReadLine();

                // Save the scores to the file.
                SaveScores(gameFileFinished, GetScoreStrings(_players));
            }
        }
    }
    public void DisplayCardValues() {
    // Display each special card value to the user.

        foreach(string value in _cardValues) {
            Console.WriteLine($"- {value}");
        }
    }
}