using System;
using System.Windows;
using System.Windows.Controls;

namespace Chapter7
{
    class Tile : Canvas
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new Tile());
        }
    }
}
