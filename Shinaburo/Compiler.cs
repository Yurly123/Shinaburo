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
        List<Function> FunctionPool = new List<Function>();

        public Compiler(ConsoleHandler console)
        {
            this.console = console;
        }
        public void Compile(string Code)
        {
            string[] Statememts = Code.Split('\n');
            for(int Line = 0; Line < Statememts.Length; Line++)
            {
                string Statement = Statememts[Line];
                Statement = Statement.Trim();

                if (Statement.Last() != '.')
                {
                    if (Statement.Last() == ':')
                    {
                        // 함수 선언
                        string TempSt = Statement;

                        Type ReturnType = Compiler.GetTypevalue(TempSt.Remove(TempSt.IndexOf(' ')));
                        if (ReturnType != typeof(void))
                        {
                            TempSt = TempSt.Substring(TempSt.IndexOf(' '));
                        }
                        TempSt = TempSt.Trim();

                        string Name = TempSt.Remove(TempSt.IndexOf(' '));
                        TempSt = TempSt.Substring(TempSt.IndexOf(' ')).Trim();

                        if (TempSt.Remove(TempSt.IndexOf(' ')) != "은" && TempSt.Remove(TempSt.IndexOf(' ')) != "는")
                        {
                            console.ShowCompileError(Line + 1, "함수 선언문에는 \'을\' 혹은 \'를\'조사가 필요합니다.");
                            return;
                        }
                        TempSt = TempSt.Substring(TempSt.IndexOf(' ')).Replace(" ", string.Empty);
                        if (TempSt != "다음과같다:")
                        {
                            console.ShowCompileError(Line + 1, "함수 선언문은 \"은(는) 다음과 같다:\"형식으로 끝나야 합니다.");
                            return;
                        }

                        FunctionPool.Add(new Function(Name, ReturnType));
                    }
                    else
                    {
                        console.ShowCompileError(Line + 1, "문장 끝에 온점('.')이 필요합니다.");
                        return;
                    }
                }
            }
        }
        public static Type GetTypevalue(string Text)
        {
            switch (Text)
            {
                case "정수":
                    return typeof(int);
                case "실수":
                    return typeof(double);
                case "문자":
                    return typeof(char);
                case "문자열":
                    return typeof(string);
                case "명제":
                    return typeof(bool);
                default:
                    return typeof(void);
            }
        }
    }

    class Function
    {
        public string Name { get; }
        public object[] Parameters { get; }
        public Type ReturnType { get; }
        public Function(string name, Type returntype, params object[] parameters)
        {
            Name = name;
            ReturnType = returntype;
            Parameters = parameters;
        }

        public void AddStatement(string statement)
        {

        }
    }
}
