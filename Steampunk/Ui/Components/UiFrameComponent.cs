namespace Steampunk.Ui.Components;

using System.Numerics;
using Raylib_cs;

class UiFrameComponent : UiBaseComponent
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

    public UiFrameComponent()
    {
        BackgroundColour = Color.White;
    }
}