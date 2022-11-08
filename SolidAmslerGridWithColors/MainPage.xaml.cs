using Microsoft.Maui.Graphics;
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
        double infoButtonSize = Math.Max(longEdge / 2.0, shortEdge) / 15.0;
        Rect infoButtonBounds = new Rect(this.Bounds.Left, this.Bounds.Top, infoButtonSize, infoButtonSize);

        mainLayout.SetLayoutFlags(infoButton, AbsoluteLayoutFlags.None);
        mainLayout.SetLayoutBounds(infoButton, infoButtonBounds);

        infoButton.Source = ImageSource.FromStream(() => FileSystem.OpenAppPackageFileAsync("Info.png").Result);

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

        var center = new Point(rectF.Width / 2.0, rectF.Height / 2.0);

        canvas.FillColor = Colors.Aqua;
        int size = 7;
        for (int row = 0; row * size < center.Y; row++)
            for (int col = 0; col * size < center.X; col++)
                if (row % 2 == 0 && (row + col) % 2 == 0)
                {
                    double left = center.X - col * size - 3 * size / 2.0;
                    double right = center.X + col * size + size / 2.0;
                    double top = center.Y - row * size - 3 * size / 2.0;
                    double bottom = center.Y + row * size + size / 2.0;

                    canvas.FillRectangle((float)left, (float)top, size, size);
                    canvas.FillRectangle((float)left, (float)bottom, size, size);
                    canvas.FillRectangle((float)right, (float)top, size, size);
                    canvas.FillRectangle((float)right, (float)bottom, size, size);
                }

        canvas.FillColor = Colors.Black;
        canvas.FillCircle(center, size * 1.2);
    }
}