namespace Steampunk.Ui;

using Steampunk.Numerics;
using Steampunk.Ui.Components;

public class UiCoords
{
    public UiCoord X { get; private set; }
    public UiCoord Y { get; private set; }

    public UiCoords(UiCoord x, UiCoord y)
    {
        X = x;
        Y = y;
    }

    public UiCoords(float xScale, int xOffset, float yScale, int yOffset)
    {
        X = new UiCoord(xScale, xOffset);
        Y = new UiCoord(yScale, yOffset);
    }
}