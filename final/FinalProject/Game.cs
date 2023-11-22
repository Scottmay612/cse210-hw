using System.ComponentModel.DataAnnotations;

public abstract class Game {
    protected string _name;
    protected List<string> _rules;
    protected List<Player> _players;
    protected int _playerAmount;
    protected int _roundNum;
    protected string _description;
    
    public void DisplayWelcomeMsg() {
        Console.WriteLine($"Welcome to {_name}!");
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
    public abstract void RunGame();
    public List<Player> OrderPlayers() {
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
        // string scoreString =         
        List<string> scoreInfo = new List<string>();
        foreach(Player player in players) {
            string playerInfo = player.ToString();
            scoreInfo.Add(playerInfo);
        }
        return scoreInfo;
    }
    public void SaveScores(string fileName, List<string> scoreInfo) {

        using(StreamWriter outputFile = new StreamWriter(fileName)) {
            outputFile.WriteLine(_roundNum);
            foreach(string scoreLine in scoreInfo) {
                outputFile.WriteLine(scoreLine);
            }
        }
    }
}