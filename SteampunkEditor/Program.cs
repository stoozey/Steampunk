﻿using Raylib_cs;

using Steampunk;
using Steampunk.Ui.Components;
using Steampunk.Ui;
using Steampunk.Numerics;

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
    Size = UiCoords.FromScale(0.2f, 1f),
    Position = UiCoords.FromScale(1.0f, 0.0f),
    Anchor = new Vector2<float>(1.0f, 0.0f),
    BackgroundColour = Color.Beige,
    Parent = container
};

UiFrameComponent assetBrowserContainer = new UiFrameComponent()
{
    Name = "AssetBrowserContainer",
    Size = UiCoords.FromScale(0.2f, 1.0f),
    Anchor = new Vector2<float>(0.0f, 1.0f),
    Position = UiCoords.FromScale(0.0f, 1.0f),
    BackgroundColour = Color.DarkBlue,
    Parent = container
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
    Parent = assetBrowserContainer
};

UiImageLabelComponent sidebarLabelBackdrop = new UiImageLabelComponent
{
    Name = "TheSusGuy",
    Size = UiCoords.FromScale(1.0f, 1.0f),
    Parent = assetBrowserLabel,
    ImagePath = "/Users/jo/Pictures/FixedJerma(1).png"
};

App.WindowTitle = "Steampunk Editor";
App.Start();