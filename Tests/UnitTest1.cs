namespace Tests;

using Steampunk;

public class UnitTest1
{
    [Fact]
    public void AppStart()
    {
        void Update(float deltaTime)
        {
            App.Close();
        }

        App.Start(Update);
    }

    [Fact]
    public void AppStartIncorrectWindowSize()
    {
        App.WindowWidth = 512;
        App.WindowHeight = -10;
        AppStart();
    }
}