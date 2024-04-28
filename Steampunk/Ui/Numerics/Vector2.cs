namespace Steampunk.Numerics;

public class Vector2<T>(T x, T y)
{
    public T X { get; set; } = x;
    public T Y { get; set; } = y;

    public T Width => X;
    public T Height => Y;
}