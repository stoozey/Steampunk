using Raylib_cs;

using Steampunk;
using Steampunk.Ui.Components;
using Steampunk.Ui;
using Steampunk.Numerics;

UiFrameComponent container = new UiFrameComponent()
{
    BackgroundColour = new Color(0, 0, 0, 0)
};

UiFrameComponent sidebar = new UiFrameComponent()
{
    Size = UiCoords.FromScale(0.2f, 1.0f),
    BackgroundColour = Color.Gray,
    Parent = container
};

UiTextLabelComponent sidebarLabel = new UiTextLabelComponent()
{
    Text = "gooner",
    TextColour = Color.Black,
    BackgroundColour = new Color(0, 0, 0, 10),
    Size = UiCoords.FromScale(0.5f, 0.2f),
    Position = UiCoords.FromScale(0.5f, 0.1f),
    Anchor = new Vector2<float>(0.5f, 0.0f),
    Parent = sidebar
};

UiImageLabelComponent sidebarLabelBackdrop = new UiImageLabelComponent
{
    Size = UiCoords.FromScale(1.0f, 1.0f),
    Parent = sidebarLabel,
    ImagePath = "/Users/jo/Pictures/FixedJerma(1).png"
};

App.WindowTitle = "Steampunk Editor";
App.Start();