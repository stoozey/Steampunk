namespace Steampunk.Ui.Components;

using Steampunk.Numerics;
using Raylib_cs;

public class UiFrameComponent : UiBaseComponent
{
    public Color BackgroundColour { get; set; }
    public float BackgroundRadius { get; set; }

    protected void RenderFrame()
    {
        Raylib.DrawRectangleRounded(
            rectangle,
            BackgroundRadius,
            16,
            BackgroundColour);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Render()
    {
        base.Render();
        RenderFrame();
    }

    public UiFrameComponent() : base()
    {
        Name = "UiFrameComponent";
        BackgroundColour = Color.White;
        BackgroundRadius = 0.0f;
    }
}