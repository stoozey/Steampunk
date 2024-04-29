namespace Steampunk;

using Steampunk.Numerics;
using Raylib_cs;
using Steampunk.Ui;
using Steampunk.Ui.Components;
using ImGuiNET;
using rlImGui_cs;

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
        if (uiComponents.Contains(component)) return;

        uiComponents.Add(component);
    }

    public static void RemoveUiComponent(UiBaseComponent component)
    {
        if (!uiComponents.Contains(component)) return;

        uiComponents.Remove(component);
    }

    public static void Start()
    {
        if (HasStarted) return;
        HasStarted = true;

        Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
        Raylib.SetTargetFPS(144);

        rlImGui.Setup(true);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(new Color(0, 0, 0, 0));
            
            Cursor.Update();
  
            foreach (UiBaseComponent component in uiComponents)
                component.Update();

            foreach (UiBaseComponent component in uiComponents)
                component.Render();

            rlImGui.Begin();
            
            rlImGui.End();

            Raylib.EndDrawing();
        }

        rlImGui.Shutdown();
        Raylib.CloseWindow();
    }

    private static void RefreshWindowSize()
    {
        Raylib.SetWindowSize(windowWidth, windowHeight);
    }
}
