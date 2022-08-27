using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shinaburo
{
    internal class ConsoleHandler
    {
        public RichTextBox console;

        public ConsoleHandler(RichTextBox console)
        {
            this.console = console;
        }
        public void PrintToConsole(string text)
        {
            console.AppendText(text);
        }
    }
}
