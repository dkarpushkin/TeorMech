using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Chapter4
{
    class ToggleTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ToggleTheButton());
        }

        public ToggleTheButton()
        {
            Title = "Toggle the button";

            ToggleButton btn = new ToggleButton();
            btn.Content = "Can _Resize";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.IsChecked = (ResizeMode == ResizeMode.CanResize);
            btn.Checked += ButtonChecked;
            btn.Unchecked += ButtonChecked;

            Content = btn;
        }

        void ButtonChecked(object sender, RoutedEventArgs args)
        {
            ToggleButton btn = sender as ToggleButton;

            ResizeMode = (bool)btn.IsChecked ? ResizeMode.CanResize : ResizeMode.NoResize;
        }
    }
}
