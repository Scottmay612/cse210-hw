public class FiveCrowns : Game {
    public FiveCrowns() {
        _name = "5 Crowns";
        _description = "For this game, you want to end with the least amount of points as possible. Each round, you will try to discard all of your cards by putting them in melds (runs or books). Each round ends after the first person lays down all of their cards. Any cards remaining will be counted as your score.";
        _roundNum = 3;
        _endingLimit = 13;
    }
    public FiveCrowns(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {}
    public void DisplayWildCard(){
        if (_roundNum <= 10) {
            Console.WriteLine($"Wild Card: {_roundNum}");
        }
        else if (_roundNum == 11) {
            Console.WriteLine($"Wild Card: Jack");
        }
        else if (_roundNum == 12) {
            Console.WriteLine($"Wild Card: Queen");
        }
        else if (_roundNum == 13) {
            Console.WriteLine($"Wild Card: King");
        }
    }
    public override void DisplayRoundMsg()
    {
        base.DisplayRoundMsg();
        Console.WriteLine($"This round, everyone will have {_roundNum} cards.");
        DisplayWildCard();
    }
}