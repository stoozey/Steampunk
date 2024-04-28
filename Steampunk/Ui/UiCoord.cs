namespace Steampunk.Ui;

public class UiCoord
{
    public float Scale { get; set; } = 0.0f;
    public int Offset { get; set; } = 0;

    public UiCoord(float scale, int offset)
    {
        Scale = scale;
        Offset = offset;
    }
}