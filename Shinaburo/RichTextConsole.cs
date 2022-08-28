using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shinaburo
{
    internal class RichTextConsole : ConsoleHandler
    {
        public RichTextBox console;

        public RichTextConsole(RichTextBox console)
        {
            this.console = console;
        }
        public void PrintToConsole(string text)
        {
            console.AppendText(text);
        }
        public void ShowCompileError(int Line, string ErrorMessage)
        {
            console.AppendText($"{Line}번째 행에서 문법 오류가 발생하였습니다.\n");
            console.AppendText(ErrorMessage);
        }
    }
}
