using System;
using System.Windows;
using System.Windows.Media;

namespace Chapter2
{
    class FollowTheRainbow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FollowTheRainbow());
        }

        public FollowTheRainbow()
        {
            Title = "Follow the rainbow";

            //LinearGradientBrush brush = new LinearGradientBrush();
            //brush.StartPoint = new Point(0, 0);
            //brush.EndPoint = new Point(1, 0);
            RadialGradientBrush brush = new RadialGradientBrush();
            Background = brush;

            brush.GradientStops.Add(new GradientStop(Colors.Red, 0));
            brush.GradientStops.Add(new GradientStop(Colors.Orange, 0.17));
            brush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.33));
            brush.GradientStops.Add(new GradientStop(Colors.Purple, 0.51));
            brush.GradientStops.Add(new GradientStop(Colors.IndianRed, 0.67));
            brush.GradientStops.Add(new GradientStop(Colors.Indigo, 0.84));
            brush.GradientStops.Add(new GradientStop(Colors.Violet, 1));
        }
    }
}
