namespace Steampunk.Ui.Components;

using System.Numerics;
using Raylib_cs;

class UiBaseComponent
{
    public UiCoords Position { get; set; }
    public UiCoords Size { get; set; }
    public Vector2 Anchor { get; set; }

    protected Rectangle rectangle;

    public virtual void Update() 
    {
        rectangle = new Rectangle(Position.X.Offset, Position.Y.Offset, Size.X.Offset, Size.Y.Offset);
    }
    
    public virtual void Render()
    {

    }

    public UiBaseComponent()
    {
        Position = new UiCoords(0.0f, 0, 0.0f, 0);
        Size = new UiCoords(1.0f, 0, 1.0f, 0);
        Anchor = new Vector2(0, 0);
    }
}