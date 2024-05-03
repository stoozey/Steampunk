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

UiImageLabelComponent sidebarLabelBackdrop = new UiImageLabelComponent
{
    Name = "TheSusGuy",
    Parent = assetBrowserLabel,
    ImagePath = "./Resources/Images/Jerma.png",
    BackgroundColour = Color.DarkGreen,
    Active = true
};

sidebarLabelBackdrop.Active = true;
sidebarLabelBackdrop.OnMouseEnterEvent += () => {
    Console.WriteLine(sidebarLabelBackdrop.Name + " entered");
};
sidebarLabelBackdrop.OnMouseExitEvent += () => {
    Console.WriteLine(sidebarLabelBackdrop.Name + " exited");
};
sidebarLabelBackdrop.OnClickStartEvent += () => {
    Console.WriteLine(sidebarLabelBackdrop.Name + " clicked");
};
sidebarLabelBackdrop.OnClickReleaseEvent += () => {
    Console.WriteLine(sidebarLabelBackdrop.Name + " released");
};

UiImageLabelComponent sidebarLabelBackdrop2 = new UiImageLabelComponent
{
    Name = "TheSusGuy2",
    Position = UiCoords.FromScale(0.5f, 0.0f),
    Parent = assetBrowserLabel,
    ImagePath = "./Resources/Images/Jerma.png",
    BackgroundColour = Color.DarkPurple,
    Active = true
};

sidebarLabelBackdrop2.OnMouseEnterEvent += () => {
    Console.WriteLine(sidebarLabelBackdrop2.Name + " entered");
};
sidebarLabelBackdrop2.OnMouseExitEvent += () => {
    Console.WriteLine(sidebarLabelBackdrop2.Name + " exited");
};
sidebarLabelBackdrop2.OnClickStartEvent += () => {
    Console.WriteLine(sidebarLabelBackdrop2.Name + " clicked");
};
sidebarLabelBackdrop2.OnClickReleaseEvent += () => {
    Console.WriteLine(sidebarLabelBackdrop2.Name + " released");
};

void Update(float deltaTime)
{

}

void Render(float deltaTime)
{

}

App.WindowTitle = "Steampunk Editor";
App.Start(Update, Render);