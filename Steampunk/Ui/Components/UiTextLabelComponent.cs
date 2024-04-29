namespace Steampunk.Ui.Components;

using Steampunk.Numerics;
using Steampunk.Ui;
using Raylib_cs;

public class UiTextLabelComponent : UiFrameComponent
{
    public string Text { get; set; }
    public Color TextColour { get; set; }

    protected void RenderTextLabel()
    {
        Vector2<int> absolutePosition = AbsolutePosition;
        Raylib.DrawText(Text, absolutePosition.X, absolutePosition.Y, 20, TextColour); 
    }

    public override void Render()
    {
        base.Render();
        RenderTextLabel();
    }

    public UiTextLabelComponent() : base()
    {
        Name = "UiTextLabelComponent";
        Text = "";
        TextColour = Color.Black;
    }
}
