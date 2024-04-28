namespace Steampunk.Ui.Components;

using Steampunk.Numerics;
using Raylib_cs;

public class UiFrameComponent : UiBaseComponent
{
    public Color BackgroundColour { get; set; }

    protected void RenderFrame()
    {
        Raylib.DrawRectangleRec(rectangle, BackgroundColour);
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
        BackgroundColour = Color.White;
    }
}