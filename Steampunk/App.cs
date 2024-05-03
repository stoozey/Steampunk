namespace Steampunk;

using Steampunk.Numerics;
using Raylib_cs;
using Steampunk.Ui;
using Steampunk.Ui.Components;
using ImGuiNET;
using rlImGui_cs;
using System.Linq;

public delegate void OnComponentAdded(UiBaseComponent component);
public delegate void OnComponentRemoved(UiBaseComponent component);

public static class App
{
    public static event OnComponentAdded OnComponentAddedEvent;
    public static event OnComponentRemoved OnComponentRemovedEvent;
    public static bool HasStarted { get; private set; } = false;
    private const string TITLE_DEFAULT = "Steampunk";
    private const int WIDTH_DEFAULT = 1024;
    private const int HEIGHT_DEFAULT = 768;
    private static long currentComponentId = 0;

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

    public static List<UiBaseComponent> GetAllComponents() => new List<UiBaseComponent>(uiComponents);

    public static long GenerateComponentId()
    {
        return currentComponentId++;
    }

    public static void SortUiComponents()
    {
        uiComponents.Sort((a, b) => a.Depth.CompareTo(b.Depth));
    }

    public static void AddUiComponent(UiBaseComponent component)
    {
        if (uiComponents.Contains(component)) return;

        uiComponents.Add(component);
        SortUiComponents();
        OnComponentAddedEvent.Invoke(component);
    }

    public static void RemoveUiComponent(UiBaseComponent component)
    {
        if (!uiComponents.Contains(component)) return;

        uiComponents.Remove(component);
        OnComponentRemovedEvent.Invoke(component);
    }

    public static void Start(Action<float>? update = null, Action<float>? render = null, Action<float>? renderImGui = null)
    {
        if (HasStarted) return;
        HasStarted = true;

        SortUiComponents();

        Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
        Raylib.SetTargetFPS(144);

        rlImGui.Setup(true);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(new Color(0, 0, 0, 0));
            
            Cursor.Update();

            float deltaTime = Raylib.GetFrameTime();
            update?.Invoke(deltaTime);
  
            foreach (UiBaseComponent component in uiComponents)
                component.Update();

            foreach (UiBaseComponent component in uiComponents)
                component.Render();

            foreach (UiBaseComponent component in uiComponents)
            {
                if (!component.IsMouseOver) continue;

                int posX = component.AbsolutePosition.X;
                int posY = component.AbsolutePosition.Y;
                int sizeX = component.AbsoluteSize.X;
                int sizeY = component.AbsoluteSize.Y;
                Raylib.DrawRectangleLines(posX, posY, sizeX, sizeY, Color.Red);
                Raylib.DrawText(component.Name, posX, posY, 16, Color.Red);
            }

            render?.Invoke(deltaTime);

            rlImGui.Begin();

            static void ShowChildren(UiBaseComponent component) 
            {
                if (ImGui.CollapsingHeader(component.Name))
                {
                    ImGui.Indent();
                    foreach (UiBaseComponent child in component.GetChildren())
                    {
                        if (child.GetChildren().Count == 0)
                            ImGui.Text(child.Name);
                        else
                            ShowChildren(child);
                    }
                    ImGui.Unindent();
                }
            }
            
            foreach (UiBaseComponent component in uiComponents.Where(c => c.Parent == null))
                ShowChildren(component);

            renderImGui?.Invoke(deltaTime);

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

    static App()
    {
        OnComponentAddedEvent += (UiBaseComponent component) => { };
        OnComponentRemovedEvent += (UiBaseComponent component) => { };
    }
}
