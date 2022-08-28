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
        string OriginalCode;
        List<string> ReservedWords = new List<string> { "을", "를", "써라" };
        string OutputBuffer = string.Empty;

        public Compiler(ConsoleHandler console)
        {
            this.console = console;
        }
        public void Compile(string Code)
        {
            OriginalCode = Code;
            // Ignore tab charator, and comments
            // 탭 문자, 주석 무시
            Code = Code.Replace("\t", string.Empty);
            string[] CommentStrings = Code.Split('(');
            if (CommentStrings.Length > 1)
            {
                Code = string.Empty;
                foreach (var commentstring in CommentStrings)
                {
                    int CommentIndex = commentstring.IndexOf(')') + 1;
                    if (CommentIndex < 0) Code += commentstring;
                    else
                    {
                        if (commentstring.Contains('\n'))
                        {
                            console.ShowCompileError(OriginalCode.Split('\n').Length - 1, "괄호가 닫히지 않은채로 문장이 끝났습니다.");
                            return;
                        }
                        Code += commentstring.Substring(CommentIndex, commentstring.Length - CommentIndex);
                    }
                }
            }
            List<string> Codes = Code.Split('\n').ToList();

            // Compile actual codes
            // 의미있는 코드들 컴파일
            for (int i = 0; i < Codes.Count; ++i)
            {
                var Statement = Codes[i];

                List<string> Tokens = new List<string>();
                foreach(string Token in Statement.Trim().Split(' '))
                {
                    if (Token != string.Empty) Tokens.Add(Token);
                }
                if (Statement.Replace(" ", string.Empty) == string.Empty) continue;
                if (Tokens.Last().Last() != '.')
                {
                    console.ShowCompileError(i + 1, "문장 마지막에 \'.\'문자가 들어가있지 않았습니다.");
                    return;
                }

                switch (Tokens.Last().Remove(Tokens.Last().Length - 1))
                {
                    case "써라":
                        if (Tokens[Tokens.Count - 2] == "를" || Tokens[Tokens.Count - 2] == "을")
                        {
                            string OutputText = Statement.Trim();
                            OutputText = OutputText.Remove(OutputText.Length - 3);
                            while (OutputText.Last() == ' ') OutputText = OutputText.Remove(OutputText.Length - 1);
                            OutputText = OutputText.Remove(OutputText.Length - 1);
                            쓰다(OutputText);
                        }
                        else
                        {
                            console.ShowCompileError(i + 1, "\"써라\" 단어 앞에 \'을(를)\' 문자가 발견되지 않았습니다.");
                            return;
                        }
                        break;
                    default:
                        console.ShowCompileError(i + 1, "알 수 없는 문자가 발견되었습니다.");
                        return;
                }
            }
            FlushOutputBuffer();
        }
        void FlushOutputBuffer()
        {
            console.PrintToConsole(OutputBuffer);
            OutputBuffer = string.Empty;
        }

        void 쓰다(string Text)
        {
            OutputBuffer += Text + '\n';
        }
    }
}
