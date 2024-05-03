namespace Steampunk;

using Steampunk.Numerics;
using Raylib_cs;
using Steampunk.Ui.Components;
using System.Linq;

static class Cursor
{
    private const int RECTANGLE_SIZE = 2;

    public static Vector2<int> Position { get; private set; }

    public static Rectangle Rectangle;
    public static bool IsOverRectangle(Rectangle rectangle) => Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rectangle);
    public static UiBaseComponent? HoveringComponent { get; private set; }

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

        List<UiBaseComponent> uiComponents = App.GetAllComponents().Where(c => c.Active).ToList();
        uiComponents.Sort((x, y) => y.Depth.CompareTo(x.Depth));

        HoveringComponent = null;
        foreach (UiBaseComponent component in uiComponents)
        {
            if (!IsOverRectangle(component.Rectangle)) continue;
            
            HoveringComponent = component;
            break;
        }
    }

    static Cursor()
    {
        Position = new Vector2<int>(0, 0);
        Rectangle = new Rectangle(0, 0, RECTANGLE_SIZE, RECTANGLE_SIZE);
    }
}