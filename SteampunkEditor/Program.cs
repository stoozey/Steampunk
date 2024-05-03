using Raylib_cs;

using Steampunk;
using Steampunk.Ui.Components;
using Steampunk.Ui;
using Steampunk.Numerics;
using Steampunk.Ui.ComponentLayouts;

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
    Text = "gooner",
    TextColour = Color.Black,
    BackgroundColour = new Color(0, 0, 0, 10),
    Size = UiCoords.FromScale(0.5f, 0.2f),
    Position = UiCoords.FromScale(0.5f, 0.1f),
    Anchor = new Vector2<float>(0.5f, 0.0f),
    Parent = assetBrowserContainer,
    Layout = new ComponentLayoutList() { Spacing = new UiCoord(0.6f, 0), Direction = ListLayoutDirection.Horizontal }
};

Dictionary<long, UiBaseComponent> components = new Dictionary<long, UiBaseComponent>();

App.OnComponentAddedEvent += (UiBaseComponent component) => {
    Console.WriteLine("Added component: " + component.Name);
};

App.OnComponentRemovedEvent += (UiBaseComponent component) => {
    Console.WriteLine("Removed component: " + component.Name);
};

void Update(float deltaTime)
{

}

void Render(float deltaTime)
{
}

App.WindowTitle = "Steampunk Editor";
App.Start(Update, Render);