public class Shape {
    private string _color;
    public string _Color {
        get {return _color;}
        set { _color = value;}
    }
    public Shape(string color) {
    _Color = color;
    }
    public virtual double GetArea()
    {return -1;}
}