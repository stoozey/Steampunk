namespace Steampunk;

using Steampunk.Numerics;
using Raylib_cs;

static class Cursor
{
    private const int RECTANGLE_SIZE = 1;

    public static Vector2<int> Position { get; private set; } = new Vector2<int>(0, 0);

    public static Rectangle Rectangle = new Rectangle(0, 0, RECTANGLE_SIZE, RECTANGLE_SIZE);

    public static void Update()
    {
        int x = Raylib.GetMouseX();
        int y = Raylib.GetMouseY();
        Position.X = x;
        Position.Y = y;

        Rectangle.X = x;
        Rectangle.Y = y;
        Rectangle.Width = (x + RECTANGLE_SIZE);
        Rectangle.Height = (y + RECTANGLE_SIZE);
    }
}