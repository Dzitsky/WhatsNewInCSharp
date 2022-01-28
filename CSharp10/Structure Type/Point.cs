public struct Point
{
    public Point()
    {
        X = 3;
        Y = 3;
    }

    public Point(double x, double y) =>
        (X, Y) = (x, y);

    public double X { get; set; }
    public double Y { get; set; }

    public override string ToString()
    {
        return $"X {X}, Y {Y}";
    }
}