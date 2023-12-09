using System.ComponentModel.DataAnnotations;

public class Game {
    protected string _name;
    protected List<string> _gameRules;
    protected List<string> _suggestions;
    protected List<Player> _players;
    protected int _playerAmount;
    protected int _roundNum;
    protected string _description;
    protected int _endingLimit;
    protected int _minimumPlayers;
    protected int _maximumPlayers;

    // Create a constructor for when there are no required parameters.
    public Game() {}

    // Create a constructor for when a game is loaded back in.
    public Game(int roundNum, string gameName, int endingLimit, List<Player> players) {
        _name = gameName;
        _roundNum = roundNum;
        _players = players;
        _endingLimit = endingLimit;
    }
    public int GetEndingLimit() {
        // Return the game's ending limit.
        return _endingLimit;
    }
    public virtual void SetInfo() {
        // Display the welcoming message and game description.
        Console.Clear();
        Console.WriteLine($"Welcome to {_name}!");

        Console.WriteLine();
        Console.WriteLine(_description);

        // Get the amount of players and each of their names.
        Console.WriteLine();
        SetPlayerAmount();
        
        // Create a new list of Players.
        _players = new List<Player>();

        // Prompt for and set the players' names.
        Console.WriteLine("What are their names?");
        SetPlayerNames(_playerAmount);
    }
    private int SetPlayerAmount() {

        // Declare the user's choice to continue even though they don't have a valid player amount.
        string continueAnyway = "";

        // Prompt for and set the amount of players for the attribute _playerAmount.
        Console.Write("How many people are playing? ");
        _playerAmount = int.Parse(Console.ReadLine());

        // Handle the case where they have the wrong amount of players.
        while((_playerAmount < _minimumPlayers || _playerAmount > _maximumPlayers) && continueAnyway != "y") {

            // Tell them they don't have the right amount of players and ask if they would like to continue anyway.
            Console.WriteLine($"The recommended amount of players is {_minimumPlayers} - {_maximumPlayers}.");
            Console.Write("Would you like to continue anyway? (y/n) ");
            continueAnyway = Console.ReadLine();

            // If they want to put in a new number, prompt for a new number.
            if(continueAnyway.ToLower() == "n") {
                Console.Write("How many players are there? ");
                _playerAmount = int.Parse(Console.ReadLine());
            }
        }

        // Return the amount of players.
        return _playerAmount;
    }
    private void SetPlayerNames(int playerAmount)
    {
        // Loop through each player using Enumerable.Range(start, count).
        foreach (int num in Enumerable.Range(0, playerAmount))
        {
            // Prompt the user for the player name.
            Console.Write($"Player {num + 1}: ");
            string playerName = Console.ReadLine();

            // Create a new Player object with the entered name.
            Player player = new Player(playerName);

            // Add the player object to the players list.
            _players.Add(player);
        }
    }

    public virtual void GetScores() {
    // Get each players score for the round.

        // Iterate through each player.
        foreach(Player player in _players) {

            // Prompt for their new score.
            Console.Write($"How many points did {player.GetName()} get? ");
            int pointsGained = int.Parse(Console.ReadLine());

            // Add the points gained to their current score.
            player.SetScore(pointsGained);
        }
    }
    protected void DisplayRules() {

        // Display header.
        Console.WriteLine($"{_name} rules: ");

        // Iterate through and display the game's rules.
        foreach(string rule in _gameRules) {
            Console.WriteLine($"- {rule}");
        }
    }
    protected void DisplaySuggestions() {

        // Display header.
        Console.WriteLine($"{_name} Suggestions: ");

        // Iterate through and display the game's suggestions.
        foreach(string suggestion in _suggestions) {
            Console.WriteLine($"- {suggestion}");
        }
    }
    public virtual void DisplayRoundMsg() {
        // Display the round number.
        Console.WriteLine($"Begin round {_roundNum} ");
    }
    public virtual void RunGame(int limit) 
    {
        // Declare the user's response for whether they would like to pause the game or continue playing.
        string continueResponse = "";
        string menuChoice = "1";

        // Continue looping while their are rounds remaining and the user has not ended the game.
        while(_roundNum <= limit && menuChoice != "3" && menuChoice != "5") {

            // Display round number.
            Console.Clear();
            DisplayRoundMsg();
            Console.WriteLine();

            // Get the round scores for each player.
            GetScores();

            // Display the current leaderboard.
            Console.WriteLine();
            Console.WriteLine("Here is the current leaderboard:");
            Thread.Sleep(250);
            DisplayLeaderBoard();

            // Give the user the option to either continue or open the menu for more options.
            Console.Write("Press enter to continue or type 'menu' for more options: ");
            continueResponse = Console.ReadLine();

            // Increment the round number by one prior to saving the file.
            _roundNum ++;

            // Get the filename. Write the round number and the player's name/scores to the file.
            if(continueResponse.ToLower() == "menu") {
                menuChoice = RunInGameMenu(menuChoice, limit);
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

    public virtual List<Player> OrderPlayers() {
        // Order the players from least points to highest points.
        List<Player> sortedList = _players.OrderBy(o=>o.GetPoints()).ToList();

        // Return the sorted list.
        return sortedList;
    }
    public virtual void DisplayLeaderBoard() {
        // Declare count to be displayed next to players names.
        int count = 1;

        // Create ranked list of players.
        List<Player> _rankedPlayers = OrderPlayers();

        foreach(Player player in _rankedPlayers) {

            // Display each players name and points amount.
            Console.WriteLine($"{count}. {player.GetName()}: {player.GetPoints()}");

            // Increment the count by one.
            count ++;

            // Briefly pause between players.
            Thread.Sleep(250);
        }
    }
    public List<string> GetScoreStrings(List<Player> players) {
        // Create a list for the score information.
        List<string> scoreInfo = new List<string>();


        foreach(Player player in players) {
            // Turn the player's information into a string.
            string playerInfo = player.ToString();

            // Add the player information to the list.
            scoreInfo.Add(playerInfo);
        }

        // Return the list of scores.
        return scoreInfo;
    }
    // This function runs the in-game menu, allowing players to access options during the game.
    public virtual string RunInGameMenu(string menuChoice, int roundLimit)
    {
        // Initially set menu choice to 1.
        menuChoice = "1";

        // Loop while the user chooses a valid option (1 or 2).
        while (menuChoice == "1" || menuChoice == "2")
        {
            // Clear the console for a clean display.
            Console.Clear();

            // Print the menu options.
            Console.WriteLine("Here are your menu options: ");
            Console.WriteLine("1. View Game Rules");
            Console.WriteLine("2. View Suggestions");
            Console.WriteLine("3. Save Game");
            Console.WriteLine("4. Return to Game");
            Console.WriteLine("5. Quit Game");

            // Prompt the user for their choice.
            Console.Write("What would you like to do? ");
            menuChoice = Console.ReadLine();

            // Switch statement to handle user input.
            switch (menuChoice)
            {
                case "1": // View game rules.
                    {
                        // Clear the console for the rules.
                        Console.Clear();

                        // Display the game rules.
                        DisplayRules();

                        // Wait for user input to continue.
                        Console.Write("Press enter to continue: ");
                        Console.ReadLine();
                        break;
                    }
                case "2": // View suggestions.
                    {
                        // Clear the console for the suggestions.
                        Console.Clear();

                        // Display suggestions for gameplay.
                        DisplaySuggestions();

                        // Wait for user input to continue.
                        Console.Write("Press enter to continue: ");
                        Console.ReadLine();
                        break;
                    }
                case "3": // Save game.
                    {
                        // Prompt the user for a filename to save the game scores.
                        Console.Write("What is the file name? ");
                        string fileName = Console.ReadLine();

                        // Save the scores to the specified file.
                        SaveScores(fileName, GetScoreStrings(_players));
                        break;
                    }
                case "4": // Return to game.
                    {
                        // Do nothing, continue the loop and return to the game.
                        break;
                    }
                case "5": // Quit game.
                    {
                        // Set the round number beyond the limit to effectively end the game.
                        _roundNum = roundLimit + 1;
                        break;
                    }
                default: // Invalid input
                    {
                        // Inform the user that their input was invalid.
                        Console.WriteLine("Please pick a valid option.");
                        break;
                    }
            }
        }
    // Return the final chosen menu option.
    return menuChoice;
}
    public void SaveScores(string fileName, List<string> scoreInfo) {
    // Write the scores to a file.

        using(StreamWriter outputFile = new StreamWriter(fileName)) {

            // Write the game information to the first line.
            outputFile.WriteLine($"game info|{_roundNum}|{_name}|{_endingLimit}");

            // Iterate through each line of player information.
            foreach(string scoreLine in scoreInfo) {

                // Write the line to the file.
                outputFile.WriteLine(scoreLine);
            }
        }
    }
}
