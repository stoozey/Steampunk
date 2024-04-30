using Steampunk.Numerics;
using Steampunk.Ui.Components;

namespace Steampunk.Ui.ComponentLayouts;

public enum ListLayoutDirection {
    Vertical,
    Horizontal
}

public enum ListLayoutHorizontalAlign {
    Left,
    Center,
    Right,
}

public enum ListLayouVerticalAlign {
    Top,
    Middle,
    Bottom,
}

public class ComponentLayoutList : ComponentLayout
{
    public ListLayoutDirection Direction { get; set; }
    public ListLayoutHorizontalAlign HorizontalAlign { get; set; }
    public ListLayouVerticalAlign VerticalAlign { get; set; }
    public UiCoord Spacing { get; set; }

    public override void Update(UiBaseComponent component)
    {
        UiCoords position = UiCoords.Zero;
        foreach (UiBaseComponent child in component.GetChildren())
        {
            child.Position = position;

            switch (Direction)
            {
                case ListLayoutDirection.Vertical:
                    position.Y.Offset += Spacing.Offset;
                    position.Y.Scale += Spacing.Scale;
                    break;
                case ListLayoutDirection.Horizontal:
                    position.X.Offset += Spacing.Offset;
                    position.X.Scale += Spacing.Scale;
                    break;
            }
        }
    }
    
    public override void Render(UiBaseComponent component)
    {
        
    }

    public ComponentLayoutList(ListLayoutDirection? direction = null, ListLayoutHorizontalAlign? horizontalAlign = null, ListLayouVerticalAlign? verticalAlign = null, UiCoord? spacing = null) : base()
    {
        Direction = (direction ?? ListLayoutDirection.Horizontal);
        HorizontalAlign = (horizontalAlign ?? ListLayoutHorizontalAlign.Left);
        VerticalAlign = (verticalAlign ?? ListLayouVerticalAlign.Top);
        Spacing = (spacing ?? UiCoord.Zero);
    }
}