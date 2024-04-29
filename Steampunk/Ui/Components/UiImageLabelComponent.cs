namespace Steampunk.Ui.Components;

using Steampunk.Numerics;
using Steampunk.Ui;
using Raylib_cs;

class UiImageLabelComponent : UiFrameComponent
{
    private string imagePath;
    public string ImagePath
    {
        get {
            return imagePath;
        }

        set {
            imagePath = value;

            if (texture != null)
                Raylib.UnloadTexture((Texture2D) texture);

            Image image = Raylib.LoadImage(imagePath);
            texture = Raylib.LoadTextureFromImage(image);
            Raylib.UnloadImage(image);
        }
    }

    public Color ImageColour { get; set; }

    protected void RenderImageLabel()
    {
        if (texture == null) return;

        Vector2<int> absolutePosition = AbsolutePosition;
        Raylib.DrawTexture((Texture2D) texture, absolutePosition.X, absolutePosition.Y, ImageColour);
    }

    private Texture2D? texture;

    public override void Render()
    {
        base.Render();
        RenderImageLabel();
    }

    public UiImageLabelComponent() : base()
    {
        texture = null;
        imagePath = "";
        ImagePath = "";
        ImageColour = Color.White;
    }

    ~UiImageLabelComponent()
    {
        if (texture != null)
            Raylib.UnloadTexture((Texture2D) texture);
    }
}
