public class Skyjo : Game {
    public Skyjo() {
        _name = "Skyjo";
        _description = "The card game Skyjo ends when a player has 100 or more points. Players add up their points, and the first player to flip over all their cards needs to have the lowest score. If they don't, or if it's tied, they have to double their score";
        _endingLimit = 100;
        _roundNum = 1;
        _gameRules = new List<string>() {
            "Gather your players: Skyjo can be played with 2-8 players.",
            "Prepare the cards: Each player receives 12 cards.",
            "Shuffle the cards: Shuffle the cards thoroughly and deal them face down to each player. Players should not look at their cards yet.",
            "Set up game: Each person lays their 12 cards facedown in a 3x4 grid.",
            "Each round: Each player will take turns drawing a card from the deck. They can either swap it for one of their current cards or discard it and flip over one of their remaining cards. If they have three identical cards in a column, they remove that column from their grid!",
            "Round end: The round ends when a player has turned over all of their remaining cards. That player needs to have the lowest score. If they don't, or if it's tied, they have to double their score.",
            "Scoring: Each person adds up their remaining cards.",
            "Game end: When a player has earned 100 points. The game is over. The player with the lowest points wins!"
        };
    }
    public Skyjo(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {
        _gameRules = new List<string>() {
            "Gather your players: Skyjo can be played with 2-8 players.",
            "Prepare the cards: Each player receives 12 cards.",
            "Shuffle the cards: Shuffle the cards thoroughly and deal them face down to each player. Players should not look at their cards yet.",
            "Set up game: Each person lays their 12 cards facedown in a 3x4 grid.",
            "Each round: Each player will take turns drawing a card from the deck. They can either swap it for one of their current cards or discard it and flip over one of their remaining cards. If they have three identical cards in a column, they remove that column from their grid!",
            "Round end: The round ends when a player has turned over all of their remaining cards. That player needs to have the lowest score. If they don't, or if it's tied, they have to double their score.",
            "Scoring: Each person adds up their remaining cards.",
            "Game end: When a player has earned 100 points. The game is over. The player with the lowest points wins!"
        };
    }
    public override void RunGame(int limit)
    {
        // Declare the user's response for whether they would like to pause the game or continue playing.
        string continueResponse = "";

        // Declare maximum score. This will change after every round of the game.
        int maximumScore = 0;

        // Continue looping while their are rounds remaining and the user has not typed save.
        while(maximumScore <= limit && continueResponse != "save") {

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

            // Give the user the option to either continue or pause the game and save their scores.
            Console.Write("Press enter to continue or type 'save' to pause your game: ");
            continueResponse = Console.ReadLine();

            // Set the maximum score equal to the new highest score out of all of the players.
            maximumScore = FindMaximumScore(_players, maximumScore);

            // Get the filename. Write the round number and the player's name/scores to the file.
            if(continueResponse.ToLower() == "save") {
                Console.Write("What is the file name? ");
                string fileName = Console.ReadLine();
                SaveScores(fileName, GetScoreStrings(_players));
            }
        }
        // Give different ending messages depending on whether the user finished the game or paused it.
        Console.WriteLine();

        if(continueResponse == "save") {
            // Display confirmation saved message.
            Console.WriteLine("Your progress is saved. Come again soon!");
        }
        else {
            // If the game is finished, display the final scores.
            Console.WriteLine("The final leaderboard is...");

            // Pause for a moment for dramatic effect.
            Thread.Sleep(1);

            // Display the scores.
            DisplayLeaderBoard();
        }    
    }
    public int FindMaximumScore(List<Player> players, int maximumScore) {
        foreach(Player player in players) {
            if (player.GetPoints() > maximumScore) {
                maximumScore = player.GetPoints();
            }
        }
        return maximumScore;
    }
}