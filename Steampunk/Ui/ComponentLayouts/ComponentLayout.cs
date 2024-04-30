using Steampunk.Ui.Components;

namespace Steampunk.Ui.ComponentLayouts;

public abstract class ComponentLayout
{
    public abstract void Update(UiBaseComponent component);

    public abstract void Render(UiBaseComponent component);
}