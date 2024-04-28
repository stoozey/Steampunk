namespace Steampunk.Numerics;

public class Vector3<T>(T x, T y, T z) : Vector2<T>(x, y)
{
    public T Z { get; set; } = z;

    public T Depth => Z;
}