namespace Steampunk.Ui;

using Steampunk.Numerics;
using Steampunk.Ui.Components;

public class UiCoords
{
    public UiCoord X { get; private set; }
    public UiCoord Y { get; private set; }

    public static UiCoords Zero => new UiCoords(UiCoord.Zero, UiCoord.Zero);

    public static UiCoords FromOffset(int xOffset, int yOffset)
    {
        return new UiCoords(0.0f, xOffset, 0.0f, yOffset); 
    }

    public static UiCoords FromScale(float xScale, float yScale)
    {
        return new UiCoords(xScale, 0, yScale, 0);
    }

    public UiCoords(UiCoord x, UiCoord y)
    {
        X = new UiCoord(x.Scale, x.Offset);
        Y = new UiCoord(y.Scale, y.Offset);
    }

    public UiCoords(float xScale, int xOffset, float yScale, int yOffset)
    {
        X = new UiCoord(xScale, xOffset);
        Y = new UiCoord(yScale, yOffset);
    }
}