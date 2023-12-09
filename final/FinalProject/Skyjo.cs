public class Skyjo : Game {

    // Constructor for when the game is initally created.
    public Skyjo() {
        _name = "Skyjo";
        _description = "The card game Skyjo ends when a player has 100 or more points. Players add up their points, and the first player to flip over all their cards needs to have the lowest score. If they don't, or if it's tied, they have to double their score";
        _endingLimit = 100;
        _roundNum = 1;
        _minimumPlayers = 2;
        _maximumPlayers = 8;

        // Game rules for the in-game menu.
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

        // Suggestions for the in-game menu.
        _suggestions = new List<string>() {
            "Never replace your card with a drawn card unless you know what your card is. You could accidentally get rid of a good card!",
            "If the person before you has a card that you need, hold onto your card for a while because they may need to get rid of theirs. That way, you can focus on other cards!",
            "Be careful when replacing a higher card with a lower card. The goal is to get matches. Therefore, three 8's is no different than three 1's. Focus on getting matches first and then focus on keeping low cards towards the end of the round.",
            "Be mindful of the person after you. If you keep giving them the cards they need, they will go out before you are ready!",
            "If you are going to go out, make sure you have the best score! If you don't, your score is doubled."
        };
    }

    // Constructor for when the game is recreated and scores are loaded back in.
    public Skyjo(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {
        
        // Game rules for the in-game menu.
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

        // Suggestions for the in-game menu.
        _suggestions = new List<string>() {
            "Never replace your card with a drawn card unless you know what your card is. You could accidentally get rid of a good card!",
            "If the person before you has a card that you need, hold onto your card for a while because they may need to get rid of theirs. That way, you can focus on other cards!",
            "Be careful when replacing a higher card with a lower card. The goal is to get matches. Therefore, three 8's is no different than three 1's. Focus on getting matches first and then focus on keeping low cards towards the end of the round.",
            "Be mindful of the person after you. If you keep giving them the cards they need, they will go out before you are ready!",
            "If you are going to go out, make sure you have the best score! If you don't, your score is doubled."
        };
    }
    public override void RunGame(int limit)
    {
        // Declare the user's response for whether they would like to pause the game or continue playing.
        string continueResponse = "";
        string menuChoice = "1";

        // Declare maximum score. This will change after every round of the game.
        int maximumScore = 0;

        // Continue looping while their are rounds remaining and the user has not ended the game.
        while(maximumScore < limit && menuChoice != "3" && menuChoice != "5") {

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
            Thread.Sleep(250);
            DisplayLeaderBoard();

            // Give the user the option to either continue or pause the game and save their scores.
            Console.Write("Press enter to continue or type 'menu' for more options: ");
            continueResponse = Console.ReadLine();

            // Set the maximum score equal to the new highest score out of all of the players.
            maximumScore = FindMaximumScore(_players, maximumScore);

            // Get the filename. Write the round number and the player's name/scores to the file.
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
    public int FindMaximumScore(List<Player> players, int maximumScore) {
    // Return the highest score out of all the players. 

        // Iterate through each player.
        foreach(Player player in players) {

            // If they have the new highest score, set maximum score to their score.
            if (player.GetPoints() > maximumScore) {
                maximumScore = player.GetPoints();
            }
        }
        // Return the maximum score.
        return maximumScore;
    }
}