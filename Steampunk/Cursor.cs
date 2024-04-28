namespace Steampunk;

using Steampunk.Numerics;
using Raylib_cs;

static class Cursor
{
    public static Vector2<int> Position { get; private set; } = new Vector2<int>(0, 0);

    public static void Update()
    {
        Position.X = Raylib.GetMouseX();
        Position.Y = Raylib.GetMouseY();

        //rectangles.Select(rectangle=>rectangle.Contains(point)).LastOrDefault()
    }
}