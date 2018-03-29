using System;
using System.Windows;
using System.Windows.Input;

namespace Petzold.InheritAppAndWindow
{
    class InheritAppAndWindow
    {
        [STAThread]
        public static void Main()
        {
            MyApplication app = new MyApplication();
            app.Run();
        }
    }

    internal class MyApplication : Application
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);
            
            MyWindow win = new MyWindow();
            win.Show();
        }
    }

    internal class MyWindow : Window
    {
        public MyWindow()
        {
            Title = "Inherit App and Window";

            Width = 300;
            Height = 200;

            Left = SystemParameters.WorkArea.Width - Width;
            Top = SystemParameters.WorkArea.Height - Height;
        }

        protected override void OnMouseDown(MouseButtonEventArgs args)
        {
            base.OnMouseDown(args);

            string strMsg = string.Format("Window clicked with {0} button at point ({1})",
                args.ChangedButton, args.GetPosition(this));
            MessageBox.Show(strMsg, Title);
        }
    }
}
