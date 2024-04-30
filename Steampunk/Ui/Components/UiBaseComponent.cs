namespace Steampunk.Ui.Components;

using Steampunk.Numerics;
using Steampunk.Ui.ComponentLayouts;
using Raylib_cs;

public class UiBaseComponent
{
    public ComponentLayout Layout { get; set; }
    public bool Visible { get; set; }
    public string Name { get; set; }
    private int depth;
    public int Depth
    {
        get {
            return (depth + (Parent?.Depth ?? 0));
        }

        set {
            depth = value;

            if (App.HasStarted)
                App.SortUiComponents();
        }
    }
    private UiBaseComponent? parent;
    public UiBaseComponent? Parent 
    {
        get {
            return parent;
        }

        set {
            UiBaseComponent? oldParent = parent;
            if (value == oldParent) return;

            parent = value;

            parent?.children.Add(this);
            oldParent?.children.Remove(this);
        }
    }
    private UiCoords position;
    public UiCoords Position
    {
        get {
            return position;
        }

        set {
            position = value;
            RegenerateRectangle();
        }
    }
    private UiCoords size;
    public UiCoords Size
    {
        get {
            return size;
        }

        set {
            size = value;
            RegenerateRectangle();
        }
    }
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

    private List<UiBaseComponent> children = new List<UiBaseComponent>();

    public List<UiBaseComponent> GetChildren() => [.. children];
    public List<UiBaseComponent> GetDescendants()
    {
        List<UiBaseComponent> descendants = new List<UiBaseComponent>();
        foreach (UiBaseComponent child in children) {
            descendants.Add(child);

            foreach (UiBaseComponent descendant in child.GetChildren()) {
                descendants.Add(descendant);
            }
        }

        return descendants;
    }

    public void RegenerateRectangle()
    {
        Vector2<int> absolutePosition = AbsolutePosition;
        Vector2<int> absoluteSize = AbsoluteSize;
        rectangle = new Rectangle(absolutePosition.X, absolutePosition.Y, absoluteSize.X, absoluteSize.Y);
    } 

    public virtual void Update() 
    {
        RegenerateRectangle();
        Layout.Update(this);
    }

    public virtual void Render()
    {
        Layout.Render(this);
    }

    public UiBaseComponent()
    {
        Name = "UiBaseComponent";
        Layout = new ComponentLayoutNone();
        Visible = true;
        depth = 0;
        Parent = null;
        position = new UiCoords(0.0f, 0, 0.0f, 0);
        size = new UiCoords(1.0f, 0, 1.0f, 0);
        Anchor = new Vector2<float>(0.0f, 0.0f);

        App.AddUiComponent(this);
    }

    ~UiBaseComponent()
    {
        App.RemoveUiComponent(this);
    }
}