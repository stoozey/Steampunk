namespace Steampunk;

using System.Numerics;
using Raylib_cs;
using Steampunk.Ui;
using Steampunk.Ui.Components;

public static class App
{
    const string TITLE_DEFAULT = "Steampunk";
    public const int WIDTH_DEFAULT = 1024;
    public const int HEIGHT_DEFAULT = 768;

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

    public static void Start()
    {
        Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
        Raylib.SetTargetFPS(144);

        UiTextLabelComponent label = new()
        {
            Text = "Hello, world!",
            Size = new UiCoords(0, 256, 0, 64),
        };

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            
            label.Render();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    private static void RefreshWindowSize()
    {
        Raylib.SetWindowSize(windowWidth, windowHeight);
    }
}
