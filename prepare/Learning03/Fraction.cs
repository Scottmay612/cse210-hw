public class Fraction
{
    private int _topNumber;
    private int _bottomNumber;

    public Fraction()
    {
        _topNumber = 1;
        _bottomNumber = 1;
    }
    public Fraction(int top)
    {
        _topNumber = top;
        _bottomNumber = 1;
    }
    public Fraction(int top, int bottom)
    {
        _topNumber = top;
        _bottomNumber = bottom;
    }
    public int GetTopNumber()
    {
        return _topNumber;
    }
    public void SetTopNumber(int top)
    {
        _topNumber = top;
    }
    public int GetBottomNumber()
    {
        return _bottomNumber;
    }
    public void SetBottomNumber(int bottom)
    {
        _bottomNumber = bottom;
    }
    public string GetFractionString()
    {
        string fractionString = $"{_topNumber}/{_bottomNumber}";
        return fractionString;
    }
    public double GetDecimalValue()
    {
        double decimalValue = (double)_topNumber/_bottomNumber;
        return decimalValue;
    }

}