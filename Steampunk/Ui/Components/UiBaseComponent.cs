namespace Steampunk.Ui.Components;

using Steampunk.Numerics;
using Raylib_cs;

public class UiBaseComponent
{
    public UiBaseComponent? Parent { get; set; } = null;
    public UiCoords Position { get; set; }
    public UiCoords Size { get; set; }
    public Vector2<float> Anchor { get; set; }

    public Vector2<int> AbsolutePosition {
        get {
            Vector2<int> basePosition, baseSize;
            if (Parent == null) {
                basePosition = new Vector2<int>(0, 0);
                baseSize = new Vector2<int>(App.WindowWidth, App.WindowHeight);
            } else {
                basePosition = Parent.AbsolutePosition;
                baseSize = Parent.AbsoluteSize;
            }

            Vector2<int> absoluteSize = AbsoluteSize;
            int x = ((int) (basePosition.X + (baseSize.Width * Position.X.Scale) - (int) (absoluteSize.X * (Anchor.X)) + Position.X.Offset));
            int y = ((int) (basePosition.Y + (baseSize.Height * Position.Y.Scale) - (int) (absoluteSize.Y * (Anchor.Y)) + Position.Y.Offset));
            return new Vector2<int>(x, y);
        }
    }

    public virtual Vector2<int> AbsoluteSize {
        get {
            Vector2<int> baseSize;
            if (Parent == null) {
                baseSize = new Vector2<int>(App.WindowWidth, App.WindowHeight);
            } else {
                baseSize = Parent.AbsoluteSize;
            }

            int width = (int) (baseSize.X * Size.X.Scale) + Size.X.Offset;
            int height = (int) (baseSize.Y * Size.Y.Scale) + Size.Y.Offset;
            return new Vector2<int>(width, height);
        }
    }

    protected Rectangle rectangle;

    public virtual void Update() 
    {
        Vector2<int> absolutePosition = AbsolutePosition;
        Vector2<int> absoluteSize = AbsoluteSize;
        rectangle = new Rectangle(absolutePosition.X, absolutePosition.Y, absoluteSize.X, absoluteSize.Y);
    }

    public virtual void Render()
    {

    }

    public UiBaseComponent()
    {
        Position = new UiCoords(0.0f, 0, 0.0f, 0);
        Size = new UiCoords(1.0f, 0, 1.0f, 0);
        Anchor = new Vector2<float>(0.0f, 0.0f);
    }
}