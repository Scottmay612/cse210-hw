public class FiveCrowns : Game {
    public FiveCrowns() {
        _name = "5 Crowns";
        _description = "For this game, you want to end with the least amount of points as possible. Each round, you will try to discard all of your cards by putting them in melds (runs or books). Each round ends after the first person lays down all of their cards. Any cards remaining will be counted as your score.";
        _roundNum = 3;
        _endingLimit = 13;
    }
    public FiveCrowns(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {}
    // public override void RunGame(int roundLimit) {

    //     // Declare the user's response for whether they would like to pause the game or continue playing.
    //     string continueResponse = "";

    //     // Continue looping while their are rounds remaining and the user has not typed save.
    //     while(_roundNum <= {roundLimit} && continueResponse != "save") {

    //         // Display round number.
    //         Console.Clear();
    //         Console.WriteLine($"Begin round {_roundNum} ");
    //         Console.WriteLine();

    //         // Get the round scores for each player.
    //         GetScores();

    //         // Display the current leaderboard.
    //         Console.WriteLine();
    //         Console.WriteLine("Here is the current leaderboard:");
    //         DisplayLeaderBoard();

    //         // Give the user the option to either continue or pause the game and save their scores.
    //         Console.Write("Press enter to continue or type 'save' to pause your game: ");
    //         continueResponse = Console.ReadLine();

    //         // Increment the round number by one prior to saving the file.
    //         _roundNum ++;

    //         // Get the filename. Write the round number and the player's name/scores to the file.
    //         if(continueResponse.ToLower() == "save") {
    //             Console.Write("What is the file name? ");
    //             string fileName = Console.ReadLine();
    //             SaveScores(fileName, GetScoreStrings(_players));
    //         }
    //     }
    //     // Give different ending messages depending on whether the user finished the game or paused it.
    //     Console.WriteLine();

    //     if(continueResponse == "save") {
    //         // Display confirmation saved message.
    //         Console.WriteLine("Your progress is saved. Come again soon!");
    //     }
    //     else {
    //         // If the game is finished, display the final scores.
    //         Console.WriteLine("The final leaderboard is...");

    //         // Pause for a moment for dramatic effect.
    //         Thread.Sleep(1);

    //         // Display the scores.
    //         DisplayLeaderBoard();
    //     }
    }