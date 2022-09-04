namespace SolidAmslerGridWithColors;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
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

#if DEBUG
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine($"Pixel width: {DeviceDisplay.Current.MainDisplayInfo.Width} / Pixel Height: {DeviceDisplay.Current.MainDisplayInfo.Height}");
        sb.AppendLine($"Density: {DeviceDisplay.Current.MainDisplayInfo.Density}");
        sb.AppendLine($"Orientation: {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
        sb.AppendLine($"Rotation: {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
        sb.AppendLine($"Refresh Rate: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");

        canvas.FontColor = Colors.LemonChiffon;
        canvas.DrawString($"{sb.ToString()} {rectF.X} {rectF.Y} {rectF.Width} {rectF.Height}", rectF, HorizontalAlignment.Left, VerticalAlignment.Top);
#endif
    }
}