using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square square = new Square("red", 4);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Yellow", 5, 3);
        shapes.Add(rectangle);

        Circle circle = new Circle("green", 3);
        shapes.Add(circle);

        foreach(Shape shape in shapes)
        {
            string color = shape._Color;
            
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}");
        }
    }
}