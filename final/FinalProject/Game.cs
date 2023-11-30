using System.ComponentModel.DataAnnotations;

public abstract class Game {
    protected string _name;
    protected List<string> _rules;
    protected List<Player> _players;
    protected int _playerAmount;
    protected int _roundNum;
    protected string _description;
    protected int _endingLimit;
    public Game() {}
    public Game(int roundNum, string gameName, int endingLimit, List<Player> players) {
        _name = gameName;
        _roundNum = roundNum;
        _players = players;
        _endingLimit = endingLimit;
    }
    public int GetEndingLimit() {
        return _endingLimit;
    }
    public void SetInfo() {
        // Display the welcoming message and game description.
        // DisplayWelcomeMsg();
        Console.WriteLine($"Welcome to {_name}!");
        Console.WriteLine(_description);

        // Get the amount of players and each of their names.
        _playerAmount = SetPlayerAmount();
        SetPlayerNames(_playerAmount);
    }
    
    public void DisplayWelcomeMsg() {
    }
    public int SetPlayerAmount() {
        Console.Write("How many people are playing? ");
        _playerAmount = int.Parse(Console.ReadLine());
        return _playerAmount;
    }
    public virtual void SetPlayerNames(int playerAmount) {
        _players = new List<Player>();
        Console.WriteLine("What are their names?");
        foreach(int num in Enumerable.Range(0,playerAmount)) {
            Console.Write($"Player {num + 1}: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            _players.Add(player);
        }
    }
    public virtual void GetScores() {
        foreach(Player player in _players) {
            Console.Write($"How may points did {player.GetName()} get? ");
            int pointsGained = int.Parse(Console.ReadLine());
            player.SetScore(pointsGained);
        }
    }
    public virtual void DisplayRoundMsg() {
        // Display the round number.
        Console.WriteLine($"Begin round {_roundNum} ");
    }
    public virtual void RunGame(int roundLimit) {
    {
        // Declare the user's response for whether they would like to pause the game or continue playing.
        string continueResponse = "";

        // Continue looping while their are rounds remaining and the user has not typed save.
        while(_roundNum <= roundLimit && continueResponse != "save") {

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
            Console.Write("Press enter to continue or type 'save' to pause your game: ");
            continueResponse = Console.ReadLine();

            // Increment the round number by one prior to saving the file.
            _roundNum ++;

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
}
    public virtual List<Player> OrderPlayers() {
        List<Player> sortedList = _players.OrderBy(o=>o.GetPoints()).ToList();
        return sortedList;
    }
    public void DisplayLeaderBoard() {
        int count = 1;
        List<Player> _rankedPlayers = OrderPlayers();
        foreach(Player player in _rankedPlayers) {
            Console.WriteLine($"{count}. {player.GetName()}: {player.GetPoints()}");
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
    public void SaveScores(string fileName, List<string> scoreInfo) {

        using(StreamWriter outputFile = new StreamWriter(fileName)) {
            outputFile.WriteLine($"game info|{_roundNum}|{_name}|{_endingLimit}");
            foreach(string scoreLine in scoreInfo) {
                outputFile.WriteLine(scoreLine);
            }
        }
    }
}