namespace Steampunk.Ui;

public class UiCoord
{
    public float Scale { get; set; }
    public int Offset { get; set; }

    public UiCoord(float scale, int offset)
    {
        Scale = scale;
        Offset = offset;
    }
}