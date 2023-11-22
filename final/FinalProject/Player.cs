public class Player {
    private string _name;
    private int _points;
    public Player(string name) {
        _points = 0;
        _name = name;
    }
    public Player(string[] strings) {
        _name = strings[1];
        _points = int.Parse(strings[2]);
    }
    public override string ToString()
    {
        string getPlayerInfo = $"player|{_name}|{_points}";
        return getPlayerInfo;
    }
    public string GetName() {
        return _name;
    }
    public int GetPoints() {
        return _points;
    }
    public void SetScore(int pointsAcquired) {
        _points += pointsAcquired;
    }




}