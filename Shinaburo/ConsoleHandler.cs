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
        public void ShowCompileError(int Line)
        {
            console.AppendText("문법 오류가 발생하였습니다.\n");
            console.AppendText($"{Line}번째 행에서 알 수 없는 문자가 발견되었습니다.");
        }
    }
}
