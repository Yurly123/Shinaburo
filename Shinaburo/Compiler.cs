using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shinaburo
{
    internal class Compiler
    {
        ConsoleHandler console;
        List<string> Code;

        public Compiler(ConsoleHandler console)
        {
            this.console = console;
        }
        public void Compile(string code)
        {
            code = code.Replace("\n", string.Empty);
            code = code.Replace("\r", string.Empty);
            code = code.Replace("\t", string.Empty);
            string[] CommentStrings = code.Split('(');
            code = string.Empty;
            foreach(var commentstring in CommentStrings)
            {
                int CommentIndex = commentstring.IndexOf(')') + 1;
                if (CommentIndex < 0) code += commentstring;
                else code += commentstring.Substring(CommentIndex, commentstring.Length - CommentIndex);
            }
            console.PrintToConsole(code);
        }
    }
}
