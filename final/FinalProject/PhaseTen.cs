using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

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
        _suggestions = new List<string>() {
            "Pay attention to the discard pile. Analyze the discarded cards to understand which cards are unavailable and adjust your strategy accordingly.",
            "Once you have laid your cards, try to finish the round as quickly as possible. If the other players have not gone out, they will be stuck on that phase for another round.",
            "Pay attention to what cards your opponents are discarding and picking up to understand their strategies and potential threats.",
            "Utilize your wild cards strategically. There is often more than one way to use them."
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
        _suggestions = new List<string>() {
            "Pay attention to the discard pile. Analyze the discarded cards to understand which cards are unavailable and adjust your strategy accordingly.",
            "Once you have laid your cards, try to finish the round as quickly as possible. If the other players have not gone out, they will be stuck on that phase for another round.",
            "Pay attention to what cards your opponents are discarding and picking up to understand their strategies and potential threats.",
            "Utilize your wild cards strategically. There is often more than one way to use them."
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
    public void DisplayPhases() {
        // Display header.
        Console.WriteLine("Phases:");

        // Number and display each phase.
        for(int i = 1; i <= 10; i ++) {
            Console.WriteLine($"- Phase{i}: {_phases[i - 1]}");
        }
    }
    public override void DisplayLeaderBoard()
    {
        // Declare count as 1.
        int count = 1;

        // Order the players in the ranked players list.
        List<Player> _rankedPlayers = OrderPlayers();

        // Display each player in the list.
        foreach(Player player in _rankedPlayers) {

            if(player.GetPoints() > 10) {

                // If the player finished the game, display "Finished".
                Console.WriteLine($"{count}. {player.GetName()}: Finished");

                // Pause for a moment between players.
                Thread.Sleep(250);
            }
            else {

                // If the player did not finish the game, display their ending phase.
                Console.WriteLine($"{count}. {player.GetName()}: Phase {player.GetPoints()}");

                // Pause for a moment between players.
                Thread.Sleep(250);
            }

            // Increment the player count by 1.
            count ++;
        }
    }
    public override void SetInfo()
    {
        // Set up normal information.
        base.SetInfo();

        // Set each player's score to 1 instead of 0.
        SetInitialScores();
    }
    public void SetInitialScores() {
        // Set each player's score to 1.
        foreach(Player player in _players) {
            player.SetScore(1);
        }
    }
    public override void GetScores()
    {
        // Iterate through each player in the game.
        foreach(Player player in _players) {

            // Ask if the player completed this phase or not.
            Console.Write($"Did {player.GetName()} finish his/her phase? (y/n) ");
            string didPass = Console.ReadLine();

            // If they finished the phase, add 1 to their score.
            if(didPass == "y") {
                player.SetScore(1);
            }
        }
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

                        // Display phases.
                        DisplayPhases();

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

    // public override string RunInGameMenu(string menuChoice, int roundLimit) {
    //     menuChoice = "1";
    //     while (menuChoice == "1" || menuChoice == "2" || menuChoice == "3") {
    //         Console.Clear();
    //         Console.WriteLine("Here are your menu options: ");
    //         Console.WriteLine("1. View Game Rules");
    //         Console.WriteLine("2. View Suggestions");
    //         Console.WriteLine("3. See All Phases");
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
    //                 DisplayPhases();
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
    //                 Console.WriteLine("Please pick a valid option.");
    //                 break;
    //             }
    //         }
    //     }
    //     return menuChoice;
    // }
    public override List<Player> OrderPlayers()
    {
        List<Player> sortedList = _players.OrderByDescending(o=>o.GetPoints()).ToList();
        return sortedList;
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

            // Give the user the option to either continue or open the menu for more options.
            Console.Write("Press enter to continue or type 'menu' for more options: ");
            continueResponse = Console.ReadLine();

            // Increment the round number by one prior to saving the file.
            _roundNum ++;

            // If they chose menu, run the in-game menu.
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

                // Save their scores to a file.
                SaveScores(gameFileFinished, GetScoreStrings(_players));
            }
        }
    }
}
