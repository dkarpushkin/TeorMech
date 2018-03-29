using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Chapter7
{
    class Empty : FrameworkElement { }

    class PlayJeuDeTacquin : Window
    {
        const int NumberOfRaws = 4;
        const int NumberOfColumns = 4;

        UniformGrid ugrid;
        int xEmpty, yEmpty, iCounter;

        Key[] keys = { Key.Left, Key.Right, Key.Up, Key.Down };
        Random rand;
        UIElement elEmptySpare = new Empty();

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new PlayJeuDeTacquin());
        }

        public PlayJeuDeTacquin()
        {
            Title = "Jeu De Tacquin";
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;
            Background = SystemColors.ControlBrush;

            StackPanel stack = new StackPanel();
            Content = stack;

            Button btn = new Button();
            btn.Content = "_Scramble";
            btn.Margin = new Thickness(10);

        }
    }
}
