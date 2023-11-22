
public class SkullKing : Game {
    public SkullKing() {
        _name = "Skull King";
        _description = "The game lasts ten rounds, and in each round, each player is dealt as many cards as the number of the round. Try to get as many points as you can!";
        _roundNum = 1;
        _endingLimit = 10;
    }
    public SkullKing(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {}
    public override List<Player> OrderPlayers()
    {
        List<Player> sortedList = _players.OrderByDescending(o=>o.GetPoints()).ToList();
        return sortedList;
    }
}