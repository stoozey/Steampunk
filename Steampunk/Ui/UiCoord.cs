namespace Steampunk.Ui;

public class UiCoord
{
    public float Scale { get; set; }
    public int Offset { get; set; }

    public static UiCoord Zero => new UiCoord(0.0f, 0);

    public UiCoord(float scale, int offset)
    {
        Scale = scale;
        Offset = offset;
    }
}