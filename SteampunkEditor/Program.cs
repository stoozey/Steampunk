using Raylib_cs;
using Steampunk;
using Steampunk.Ui.Components;
using Steampunk.Ui;
using Steampunk.Numerics;
using Steampunk.Ui.ComponentLayouts;
using ImGuiNET;

UiFrameComponent container = new UiFrameComponent()
{
    Name = "Container",
    BackgroundColour = new Color(0, 0, 0, 0)
};

UiFrameComponent titlebarContainer = new UiFrameComponent()
{
    Name = "TitlebarContainer",
    Size = UiCoords.FromScale(1.0f, 0.1f),
    BackgroundColour = Color.Gray,
    Parent = container
};

UiFrameComponent actionMenuContainer = new UiFrameComponent()
{
    Name = "ActionMenuContainer",
    Size = UiCoords.FromScale(0.2f, 0.9f),
    Position = UiCoords.FromScale(1.0f, 1.0f),
    Anchor = new Vector2<float>(1.0f, 1.0f),
    BackgroundColour = Color.Beige,
    Parent = container
};

UiFrameComponent assetBrowserContainer = new UiFrameComponent()
{
    Name = "AssetBrowserContainer",
    Size = UiCoords.FromScale(0.2f, 0.9f),
    Anchor = new Vector2<float>(0.0f, 1.0f),
    Position = UiCoords.FromScale(0.0f, 1.0f),
    BackgroundColour = Color.DarkBlue,
    Parent = container,
};

UiTextLabelComponent assetBrowserLabel = new UiTextLabelComponent()
{
    Name = "SidebarLabel",
    Text = "",
    TextColour = Color.Black,
    BackgroundColour = new Color(0, 0, 0, 10),
    Size = UiCoords.FromScale(0.95f, 0.9f),
    Position = UiCoords.FromScale(0.5f, 0.1f),
    Anchor = new Vector2<float>(0.5f, 0.0f),
    Parent = assetBrowserContainer,
    Layout = new ComponentLayoutList() { Spacing = new UiCoord(0.6f, 0), Direction = ListLayoutDirection.Horizontal }
};

UiFrameComponent newComponentContainer = new UiFrameComponent()
{
    Name = "NewComponentContainer",
    Size = UiCoords.FromScale(1.0f, 0.33f),
    BackgroundColour = Color.DarkBlue,
    Parent = assetBrowserLabel,
};

UiTextLabelComponent newComponentLabel = new UiTextLabelComponent()
{
    Text = "Create New Component",
    TextColour = Color.White,
    Size = UiCoords.FromScale(1.0f, 0.1f),
    Parent = newComponentContainer
};

Dictionary<long, UiBaseComponent> components = new Dictionary<long, UiBaseComponent>();

App.OnComponentAddedEvent += (UiBaseComponent component) => {
    Console.WriteLine("Added component: " + component.Name);
};

App.OnComponentRemovedEvent += (UiBaseComponent component) => {
    Console.WriteLine("Removed component: " + component.Name);
};

bool menuBarEnabled = true;

void Update(float deltaTime)
{
    if (Raylib.IsKeyPressed(KeyboardKey.LeftAlt)) menuBarEnabled = !menuBarEnabled;
}

void Render(float deltaTime)
{

}

void RenderImGui(float deltaTime)
{
    if (menuBarEnabled)
    {
        if (ImGui.BeginMainMenuBar())
        {
            if (ImGui.BeginMenu("File"))
            {
                if (ImGui.MenuItem("Exit"))
                {}

                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Window"))
            {
               
                ImGui.EndMenu();
            }
            ImGui.EndMainMenuBar();
        }
    }
}

App.WindowTitle = "Steampunk Editor";
App.Start(Update, Render, RenderImGui);