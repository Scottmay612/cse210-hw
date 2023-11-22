public class Golf : Game {
    public Golf() {
        _name = "Golf";
        _description = "This game is created after real life Golf. Therefore, the goal is to get the lowest amount of points possible.";
        _roundNum = 1;
        _endingLimit = 9;
    }
    public Golf(int roundNum, string gameName, int roundLimit, List<Player> players) : base(roundNum,gameName,roundLimit,players) {}
}