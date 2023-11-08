using System.Reflection.Metadata.Ecma335;

public class Square : Shape {
    private float _side;
    public Square(string color, float side) : base (color) {
        _side = side;
    }
    public override double GetArea()
    {
        return _side * _side;
    }
}