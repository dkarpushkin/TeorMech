using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Chapter3
{
    class FormatTheText : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatTheText());
        }

        public FormatTheText()
        {
            Title = "Format the text";

            TextBlock text = new TextBlock();
            text.FontSize = 32;
            text.Inlines.Add("This is some ");
            text.Inlines.Add(new Italic(new Run("italic")));
            text.Inlines.Add(" text. And this is some ");
            text.Inlines.Add(new Bold(new Run("bold")));
            text.Inlines.Add(" text. And lets cap it off with some ");
            text.Inlines.Add(new Bold(new Italic(new Run("bold italic"))));
            text.Inlines.Add(" text.");

            text.TextWrapping = TextWrapping.Wrap;

            Content = text;
        }
    }
}
