public class CoverYourAssets : Game {

    // Constructor for when the game is initally created.
    public CoverYourAssets() {
        _name = "Cover Your Assets";
        _description = "Cover Your Assets is a fast-paced, easy-to-learn card game where players try to steal each other's assets to become the first millionaire.";
        _roundNum = 1;
        _endingLimit = 1000000;

        // Game rules for the in-game menu.
        _gameRules = new List<string>() {
            "Players: Cover Your Assets can be played with 2-6 players.",
            "Deal cards: Each player gets 5 cards. Place the remaining deck in the center of the table.",
            "Game play: Form a set by matching two cards together and setting them on your pile. Each new set of cards must be stacked opposite from the last to keep them separate.",
            "Challenge: During a player's turn, they can challenge another player for a set. The two players take turn laying down the same card as what is in the set. If a player has no more of that card, they lose and the other person keeps the set.",
            "Turn end: At the end of your turn, replenish your hand to 5 cards.",
            "Round end: When the whole deck has been depleted, each player counts their sets to see how much money they earned. Then, the process is repeated over again.",
            "Game end: The first player to become a millionaire wins the game!"
        };

        // Suggestions for the in-game menu.
        _suggestions = new List<string>() {
            "When creating your base, try to use the highest numbers you can because nobody can touch it.",
            "Do not attempt to steal from another player unless you have plenty of cards to back yourself up.",
            "Wait to steal until after everyone has already fought for the cards. Then, nobody has anything left to defend themselves with and you can take it for good!.",
            "If you end up with a big pile, add as many layers on top of it as can!",
            "Be patient and only make your moves when you have a high chance of success."
        };
    }
    // Create a constructor for when a game is loaded back in.
    public CoverYourAssets(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {
        
        // Game rules for the in-game menu.
        _gameRules = new List<string>() {
            "Players: Cover Your Assets can be played with 2-6 players.",
            "Deal cards: Each player gets 5 cards. Place the remaining deck in the center of the table.",
            "Game play: Form a set by matching two cards together and setting them on your pile. Each new set of cards must be stacked opposite from the last to keep them separate.",
            "Challenge: During a player's turn, they can challenge another player for a set. The two players take turn laying down the same card as what is in the set. If a player has no more of that card, they lose and the other person keeps the set.",
            "Turn end: At the end of your turn, replenish your hand to 5 cards.",
            "Round end: When the whole deck has been depleted, each player counts their sets to see how much money they earned. Then, the process is repeated over again.",
            "Game end: The first player to become a millionaire wins the game!"
        };

        // Suggestions for the in-game menu.
        _suggestions = new List<string>() {
            "When creating your base, try to use the highest numbers you can because nobody can touch it.",
            "Do not attempt to steal from another player unless you have plenty of cards to back yourself up.",
            "Wait to steal until after everyone has already fought for the cards. Then, nobody has anything left to defend themselves with and you can take it for good!.",
            "If you end up with a big pile, add as many layers on top of it as can!",
            "Be patient and only make your moves when you have a high chance of success."
        };
    }
    public override void RunGame(int limit)
    {
        // Declare the user's response for whether they would like to pause the game or continue playing.
        string continueResponse = "";
        string menuChoice = "1";

        // Declare maximum score. This will change after every round of the game.
        int maximumScore = 0;

        // Continue looping while their are rounds remaining and the user has not typed save.
        while(maximumScore <= limit && menuChoice != "3" && menuChoice != "5") {

            // Display round number.
            Console.Clear();
            DisplayRoundMsg();
            Console.WriteLine();
            _roundNum ++;

            // Get the round scores for each player.
            GetScores();

            // Display the current leaderboard.
            Console.WriteLine();
            Console.WriteLine("Here is the current leaderboard:");
            DisplayLeaderBoard();

            // Give the user the option to either continue or open the menu for more options.
            Console.Write("Press enter to continue or type 'menu' for more options: ");
            continueResponse = Console.ReadLine();

            // Set the maximum score equal to the new highest score out of all of the players.
            maximumScore = FindMaximumScore(_players, maximumScore);

            // Run the in-game menu if they typed menu.
            if(continueResponse.ToLower() == "menu") {
                menuChoice = RunInGameMenu(menuChoice, limit);
            }
        }
        // Give different ending messages depending on whether the user finished the game or paused it.
        Console.WriteLine();

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

            // Ask if they would like to save their final scores.
            Console.Write("Would you like to save your scores? (y/n) ");
            string saveResponse = Console.ReadLine();

            if (saveResponse == "y") {
                // If they want to save their final scores, prompt for the file name.
                Console.Write("What is the file name? ");
                string gameFileFinished = Console.ReadLine();

                // Save their scores to the file.
                SaveScores(gameFileFinished, GetScoreStrings(_players));
            }
        }
    }

public int FindMaximumScore(List<Player> players, int maximumScore)
{
    // Iterate through each player in the provided list.
    foreach (Player player in players)
    {
        // Retrieve the current player's score.
        int playerScore = player.GetPoints();

        // Check if the current player's score is greater than the current maximum score.
        if (playerScore > maximumScore)
        {
            // Update the maximum score to the current player's score.
            maximumScore = playerScore;
        }
    }

    // Return the updated maximum score.
    return maximumScore;
}
    public override void DisplayLeaderBoard() {

        // Declare the count as 1.
        int count = 1;

        // Create a list of players in the correct order.
        List<Player> _rankedPlayers = OrderPlayers();

        // Iterate through each player in the list.
        foreach(Player player in _rankedPlayers) {

            // Format the players points so that it has commas.
            int playerPoints = player.GetPoints();
            string formattedNumber = string.Format("{0:N0}", playerPoints);

            // Display the name and score.
            Console.WriteLine($"{count}. {player.GetName()}: {formattedNumber}");

            // Increment count by 1.
            count ++;
        }
    }    
    public override List<Player> OrderPlayers()
    {
        // Order players from greatest to least. 
        List<Player> sortedList = _players.OrderByDescending(o=>o.GetPoints()).ToList();

        return sortedList;
    }
}