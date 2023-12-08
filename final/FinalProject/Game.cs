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

    // Create a constructor for 
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
        Console.Write("How many people are playing? ");
        SetPlayerAmount();
        
        // Create a new list of Players.
        _players = new List<Player>();

        // Prompt for and set the players' names.
        Console.WriteLine("What are their names?");
        SetPlayerNames(_playerAmount);
    }
    private int SetPlayerAmount() {
        // Set the amount of players for the attribute _playerAmount.
        _playerAmount = int.Parse(Console.ReadLine());

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

    // private void SetPlayerNames(int playerAmount) {
    //     foreach(int num in Enumerable.Range(0,playerAmount)) {
    //         Console.Write($"Player {num + 1}: ");
    //         string playerName = Console.ReadLine();
    //         Player player = new Player(playerName);
    //         _players.Add(player);
    //     }
    // }
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

        // Continue looping while their are rounds remaining and the user has not typed save.
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
            DisplayLeaderBoard();

            // Give the user the option to either continue or pause the game and save their scores.
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

            Console.Write("Would you like to save your scores? (y/n) ");
            string saveResponse = Console.ReadLine();

            if (saveResponse == "y") {
                Console.Write("What is the file name? ");
                string gameFileFinished = Console.ReadLine();
                SaveScores(gameFileFinished, GetScoreStrings(_players));
            }
        }
    }

    public virtual List<Player> OrderPlayers() {
        List<Player> sortedList = _players.OrderBy(o=>o.GetPoints()).ToList();
        return sortedList;
    }
    public virtual void DisplayLeaderBoard() {
        int count = 1;
        List<Player> _rankedPlayers = OrderPlayers();
        foreach(Player player in _rankedPlayers) {
            Console.WriteLine($"{count}. {player.GetName()}: {player.GetPoints()}");
            Thread.Sleep(250);
            count ++;
        }
    }
    public List<string> GetScoreStrings(List<Player> players) {
        List<string> scoreInfo = new List<string>();
        foreach(Player player in players) {
            string playerInfo = player.ToString();
            scoreInfo.Add(playerInfo);
        }
        return scoreInfo;
    }
    public virtual string RunInGameMenu(string menuChoice, int roundLimit) {
        menuChoice = "1";
        while (menuChoice == "1" || menuChoice == "2") {
            Console.Clear();
            Console.WriteLine("Here are your menu options: ");
            Console.WriteLine("1. View Game Rules");
            Console.WriteLine("2. View Suggestions");
            Console.WriteLine("3. Save Game");
            Console.WriteLine("4. Return to Game");
            Console.WriteLine("5. Quit Game");
            Console.Write("What would you like to do? ");
            menuChoice = Console.ReadLine();
            switch (menuChoice) {
                case "1": {
                    Console.Clear();
                    DisplayRules();
                    Console.Write("Press enter to continue: ");
                    Console.ReadLine();
                    break;
                }
                case "2": {
                    Console.Clear();
                    DisplaySuggestions();
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
                default: {
                    Console.WriteLine("Please pick a valid option.");
                    break;
                }
            }
        }
        return menuChoice;
    }    
    
    public void SaveScores(string fileName, List<string> scoreInfo) {

        using(StreamWriter outputFile = new StreamWriter(fileName)) {
            outputFile.WriteLine($"game info|{_roundNum}|{_name}|{_endingLimit}");
            foreach(string scoreLine in scoreInfo) {
                outputFile.WriteLine(scoreLine);
            }
        }
    }
}
