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

public enum ListLayoutVerticalAlign {
    Top,
    Middle,
    Bottom,
}

public class ComponentLayoutList : ComponentLayout
{
    public ListLayoutDirection Direction { get; set; }
    public ListLayoutHorizontalAlign HorizontalAlign { get; set; }
    public ListLayoutVerticalAlign VerticalAlign { get; set; }
    public UiCoord Spacing { get; set; }

    public override void Update(UiBaseComponent component)
    {
        UiCoords position = UiCoords.Zero;//new UiCoords(HorizontalAlign == ListLayoutHorizontalAlign.Left? 0 : (HorizontalAlign == ListLayoutHorizontalAlign.Center? 0.5f : 1), 0, VerticalAlign == ListLayoutVerticalAlign.Top? 0 : (VerticalAlign == ListLayoutVerticalAlign.Middle? 0.5f : 1), 0);

        foreach (UiBaseComponent child in component.GetChildren())
        {
            child.Position = new UiCoords(position.X, position.Y);

            switch (Direction)
            {
                case ListLayoutDirection.Vertical:
                    position.Y.Offset += Spacing.Offset * (VerticalAlign == ListLayoutVerticalAlign.Top? 1 : (VerticalAlign == ListLayoutVerticalAlign.Middle? 2 : 3));
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

    public ComponentLayoutList(ListLayoutDirection? direction = null, ListLayoutHorizontalAlign? horizontalAlign = null, ListLayoutVerticalAlign? verticalAlign = null, UiCoord? spacing = null) : base()
    {
        Direction = (direction ?? ListLayoutDirection.Horizontal);
        HorizontalAlign = (horizontalAlign ?? ListLayoutHorizontalAlign.Left);
        VerticalAlign = (verticalAlign ?? ListLayoutVerticalAlign.Top);
        Spacing = (spacing ?? UiCoord.Zero);
    }
}