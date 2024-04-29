namespace Steampunk.Ui.Components;

using Steampunk.Numerics;
using Steampunk.Ui;
using Raylib_cs;

public class UiImageLabelComponent : UiFrameComponent
{
    private string? imagePath;
    public string? ImagePath
    {
        get {
            return imagePath;
        }

        set {
            imagePath = value;

            if (App.HasStarted)
                UnloadTexture();
        }
    }

    public Color ImageColour { get; set; }

    protected void RenderImageLabel()
    {
        if (ImagePath == null) return;

        if (texture == null)
        {
            LoadTexture();
            return;
        }

        Vector2<int> absolutePosition = AbsolutePosition;
        Vector2<int> absoluteSize = AbsoluteSize;
        Raylib.DrawTexturePro((Texture2D) texture, new Rectangle(0, 0, imageWidth, imageHeight), new Rectangle(absolutePosition.X, absolutePosition.Y, absoluteSize.X, absoluteSize.Y), System.Numerics.Vector2.Zero, 0, ImageColour);
    }

    private Texture2D? texture;
    private int imageWidth;
    private int imageHeight;

    public override void Render()
    {
        base.Render();
        RenderImageLabel();
    }

    private void LoadTexture()
    {
        UnloadTexture();

        Image image = Raylib.LoadImage(ImagePath);
        imageWidth = image.Width;
        imageHeight = image.Height;

        texture = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);
    }

    private void UnloadTexture()
    {
        if (texture != null)
            Raylib.UnloadTexture((Texture2D) texture);
    }

    public UiImageLabelComponent() : base()
    {
        texture = null;
        ImagePath = null;
        ImageColour = Color.White;
    }

    ~UiImageLabelComponent()
    {
        UnloadTexture();
    }
}
