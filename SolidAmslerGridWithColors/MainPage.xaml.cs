using Microsoft.Maui.Layouts;

namespace SolidAmslerGridWithColors;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void ShowPrivacyPolicy(object sender, EventArgs e)
    {
        Browser.Default.OpenAsync("https://raw.githubusercontent.com/wx2486/SolidAmslerGridWithColors/main/PrivacyPolicy.txt", BrowserLaunchMode.SystemPreferred);
    }

    private void SetChildrenSize(object sender, EventArgs e)
    {
        AbsoluteLayout mainLayout = this.Content as AbsoluteLayout;
        ImageButton infoButton = mainLayout.First(_ => (_ as Element).ClassId is "InfoButton") as ImageButton;

        double longEdge = Math.Max(this.Bounds.Width, this.Bounds.Height);
        double shortEdge = Math.Min(this.Bounds.Width, this.Bounds.Height);
        double infoButtonSize = Math.Max(longEdge / 2.0, shortEdge) / 20.0;
        Rect infoButtonBounds = new Rect(this.Bounds.Left, this.Bounds.Top, infoButtonSize, infoButtonSize);

        mainLayout.SetLayoutFlags(infoButton, AbsoluteLayoutFlags.None);
        mainLayout.SetLayoutBounds(infoButton, infoButtonBounds);

        GraphicsView mainFrame = mainLayout.First(_ => (_ as Element).ClassId is "MainFrame") as GraphicsView;
        mainLayout.SetLayoutFlags(mainFrame, AbsoluteLayoutFlags.None);
        mainLayout.SetLayoutBounds(mainFrame, this.Bounds);
    }
}

public class MainFrame : IDrawable
{
    public void Draw(ICanvas canvas, RectF rectF)
    {
        canvas.FillColor = Colors.SaddleBrown;
        canvas.FillRectangle(rectF);

        canvas.FillColor = Colors.Aqua;
        int size = 7;
        for (int row = 0; row * size < rectF.Height; row++)
            for (int col = 0; col * size < rectF.Width; col++)
                if (row % 2 == 0 && (row + col) % 2 == 0)
                    canvas.FillRectangle(col * size, row * size, size, size);
    }
}