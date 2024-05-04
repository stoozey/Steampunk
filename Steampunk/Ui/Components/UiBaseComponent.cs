namespace Steampunk.Ui.Components;

using Steampunk.Numerics;
using Steampunk.Ui.ComponentLayouts;
using Raylib_cs;

public delegate void OnClickStart();
public delegate void OnClickRelease();
public delegate void OnMouseEnter();
public delegate void OnMouseExit();
public delegate void OnChildAdded(UiBaseComponent child);
public delegate void OnChildRemoved(UiBaseComponent child);
public delegate void OnDestroyed();
public delegate void OnVisibleChanged();

public class UiBaseComponent
{
    public long Id { get; private set; }
    public event OnClickStart OnClickStartEvent;
    public event OnClickRelease OnClickReleaseEvent;
    public event OnMouseEnter OnMouseEnterEvent;
    public event OnMouseExit OnMouseExitEvent;
    public event OnChildAdded OnChildAddedEvent;
    public event OnChildRemoved OnChildRemovedEvent;
    public event OnDestroyed OnDestroyedEvent;
    public event OnVisibleChanged OnVisibleChangedEvent;
    public bool IsMouseOver {
        get {
            return (Cursor.HoveringComponent == this);
        }
    }
    public bool IsMouseDown { get; protected set; }
    public bool Active { get; set; }
    public ComponentLayout? Layout { get; set; }
    public bool Visible { get; set; }
    public string Name { get; set; }
    private bool destroyed;
    private int depth;
    public int Depth
    {
        get {
            return (depth + (Parent?.Depth ?? 0) + 1);
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

            if (parent != null) parent.OnDestroyedEvent += () => Destroy();
            if (oldParent != null) oldParent.OnDestroyedEvent -= () => Destroy();
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

    public Rectangle Rectangle { get; protected set; }

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

    public void Destroy()
    {
        if (destroyed) return;
        destroyed = true;

        Parent = null;
        App.RemoveUiComponent(this);
        this.OnDestroyedEvent.Invoke();
    }

    public void RegenerateRectangle()
    {
        Vector2<int> absolutePosition = AbsolutePosition;
        Vector2<int> absoluteSize = AbsoluteSize;
        Rectangle = new Rectangle(absolutePosition.X, absolutePosition.Y, absoluteSize.X, absoluteSize.Y);
    } 

    private void CheckForMouse()
    {
        if (!Active) return;

        // update mouse down/released events
        bool mouseDownLast = IsMouseDown;
        if ((IsMouseOver) && (Raylib.IsMouseButtonPressed(MouseButton.Left)))
        {
            IsMouseDown = true;
            OnClickStartEvent.Invoke();
        }
        
        if ((Raylib.IsMouseButtonReleased(MouseButton.Left)))
        {
            IsMouseDown = false;
            OnClickReleaseEvent.Invoke();
        }
    }

    public virtual void Update() 
    {
        RegenerateRectangle();
        CheckForMouse();

        Layout?.Update(this);
    }

    public virtual void Render()
    {
        Layout?.Render(this);
    }

    public UiBaseComponent()
    {
        destroyed = false;
        Id = App.GenerateComponentId();
        Active = true;
        Name = "UiBaseComponent";
        Layout = null;
        Visible = true;
        depth = 0;
        Parent = null;
        position = new UiCoords(0.0f, 0, 0.0f, 0);
        size = new UiCoords(1.0f, 0, 1.0f, 0);
        Anchor = new Vector2<float>(0.0f, 0.0f);
        IsMouseDown = false;

        OnClickStartEvent += () => { };
        OnClickReleaseEvent += () => { };
        OnMouseEnterEvent += () => { };
        OnMouseExitEvent += () => { };
        OnChildAddedEvent += (UiBaseComponent child) => { };
        OnChildRemovedEvent += (UiBaseComponent child) => { };
        OnDestroyedEvent += () => { };
        OnVisibleChangedEvent += () => { };

        App.AddUiComponent(this);
    }

    ~UiBaseComponent()
    {
        Destroy();
    }
}