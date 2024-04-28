namespace Steampunk;

using Steampunk.Numerics;
using Raylib_cs;
using Steampunk.Ui;
using Steampunk.Ui.Components;

public static class App
{
    public static bool HasStarted { get; private set; } = false;
    private const string TITLE_DEFAULT = "Steampunk";
    private const int WIDTH_DEFAULT = 1024;
    private const int HEIGHT_DEFAULT = 768;

    private static List<UiBaseComponent> uiComponents = new List<UiBaseComponent>();
    private static int windowWidth = WIDTH_DEFAULT;
    public static int WindowWidth {
        get {
            return windowWidth;
        }

        set {
            windowWidth = value;
            RefreshWindowSize();
        }
    }

    private static int windowHeight = HEIGHT_DEFAULT;
    public static int WindowHeight {
        get {
            return windowHeight;
        }

        set {
            windowHeight = value;
            RefreshWindowSize();
        }
    }

    private static string windowTitle = TITLE_DEFAULT;
    public static string WindowTitle {
        get {
            return windowTitle;
        }

        set {
            windowTitle = value;
            Raylib.SetWindowTitle(windowTitle);
        }
    }

    public static void AddUiComponent(UiBaseComponent component)
    {
        uiComponents.Add(component);
    }

    public static void RemoveUiComponent(UiBaseComponent component)
    {
        uiComponents.Remove(component);
    }

    public static void Start()
    {
        if (HasStarted) return;
        HasStarted = true;

        Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
        Raylib.SetTargetFPS(144);

        UiFrameComponent container = new()
        {
            Size = new UiCoords(0.5f, 0, 0.5f, 0),
            Position = new UiCoords(0.5f, 0, 0.5f, 0),
            Anchor = new Vector2<float>(0.5f, 0.5f),
            BackgroundColour = Color.Gray
        };

        UiTextLabelComponent label = new()
        {
            Text = "Hello, world!",
            Position = new UiCoords(0.25f, 0, 0.5f, 0),
            Size = new UiCoords(0.5f, 0, 0.5f, 0),
            Anchor = new Vector2<float>(0.25f, 0.5f),
            Parent = container
        };

        UiFrameComponent cursor = new()
        {
            Size = new UiCoords(0, 32, 0, 32),
            Position = new UiCoords(0.5f, 0, 0.5f, 0),
            Anchor = new Vector2<float>(0.5f, 0.5f),
            BackgroundColour = Color.Red
        };

        AddUiComponent(container);
        AddUiComponent(label);
        AddUiComponent(cursor);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            
            Cursor.Update();
            cursor.Position = new UiCoords(0, Cursor.Position.X, 0, Cursor.Position.Y); 
            
            foreach (UiBaseComponent component in uiComponents)
                component.Update();

            foreach (UiBaseComponent component in uiComponents)
                component.Render();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    private static void RefreshWindowSize()
    {
        Raylib.SetWindowSize(windowWidth, windowHeight);
    }
}
