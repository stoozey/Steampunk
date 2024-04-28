namespace Steampunk.Ui.Components;

using System.Numerics;
using Steampunk.Ui;
using Raylib_cs;

class UiTextLabelComponent : UiFrameComponent
{
    public string Text { get; set; }
    public Color TextColour { get; set; }

    protected void RenderTextLabel() 
    {
        Raylib.DrawText(Text, Position.X.Offset, Position.Y.Offset, 20, TextColour); 
    }

    public override void Render()
    {
        base.Render();
        RenderTextLabel();
    }

    public UiTextLabelComponent()
    {
        Text = "";
        TextColour = Color.Black;
    }
}