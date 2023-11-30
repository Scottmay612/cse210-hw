public class Canasta : Game {
    public Canasta() {
        _name = "Canasta";
        _description = "Canasta is a card game where players meld cards to score points and race to reach 5,000 points or go out by getting rid of all their cards.";
        _roundNum = 1;
        _endingLimit = 5000;
    }
    public Canasta(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {}
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
    public override void SetPlayerNames(int playerAmount) {
        _players = new List<Player>();
        Console.WriteLine("What are their names?");
        foreach(int num in Enumerable.Range(0,playerAmount)) {
            Console.Write($"Player {num + 1}: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            _players.Add(player);
        }
    }
}