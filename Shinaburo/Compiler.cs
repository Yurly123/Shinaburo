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
        List<string> Codes;

        public Compiler(ConsoleHandler console)
        {
            this.console = console;
        }
        public void Compile(string OriginalCode)
        {
            string Code = OriginalCode;
            // Ignore line alignment, tab charator, and comments
            // 개행 문자, 탭 문자, 주석 무시
            Code = Code.Replace("\n", string.Empty);
            Code = Code.Replace("\r", string.Empty);
            Code = Code.Replace("\t", string.Empty);
            string[] CommentStrings = Code.Split('(');
            Code = string.Empty;
            foreach(var commentstring in CommentStrings)
            {
                int CommentIndex = commentstring.IndexOf(')') + 1;
                if (CommentIndex < 0) Code += commentstring;
                else Code += commentstring.Substring(CommentIndex, commentstring.Length - CommentIndex);
            }
            if (Code == string.Empty) return;
            Codes = Code.Split('.').ToList();

            // Compile actual codes
            // 의미있는 코드들 컴파일
            foreach(var code in Codes)
            {
                List<string> Tokens = code.Split(' ').ToList();
                switch (Tokens.Last())
                {
                    default:
                        int ErrorIndex = OriginalCode.Replace("\n", string.Empty).IndexOf(code) + OriginalCode.Split('\n').Length - 1;
                        console.ShowCompileError(OriginalCode.Substring(0, ErrorIndex).Split('\n').Length);
                        return;
                }
            }
        }
    }
}
