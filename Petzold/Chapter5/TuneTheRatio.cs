using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chapter5
{
    class TuneTheRatio : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new TuneTheRatio());
        }

        public TuneTheRatio()
        {
            Title = "Tune the ration";

            SizeToContent = SizeToContent.WidthAndHeight;

            GroupBox group = new GroupBox();
            group.Header = "Window style";
            group.Margin = new Thickness(96);
            group.Padding = new Thickness(5);

            Content = group;

            StackPanel sPanel = new StackPanel();
            group.Content = sPanel;

            sPanel.Children.Add(
                CreateRadioButton("No border or caption", WindowStyle.None));

            sPanel.Children.Add(
                CreateRadioButton("Single border window", WindowStyle.SingleBorderWindow));

            sPanel.Children.Add(
                CreateRadioButton("3D-border window", WindowStyle.ThreeDBorderWindow));

            sPanel.Children.Add(
                CreateRadioButton("Tool window", WindowStyle.ToolWindow));

            AddHandler(RadioButton.CheckedEvent, new RoutedEventHandler(RadioOnChecked));
        }

        UIElement CreateRadioButton(string caption, WindowStyle style)
        {
            RadioButton radio = new RadioButton();
            radio.Content = caption;
            radio.Tag = style;
            radio.Margin = new Thickness(5);
            radio.IsChecked = (style == WindowStyle);

            return radio;
        }

        void RadioOnChecked(object sender, RoutedEventArgs args)
        {
            RadioButton radio = args.Source as RadioButton;

            WindowStyle = (WindowStyle)radio.Tag;
        }
    }
}
