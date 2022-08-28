using System;

namespace Shinaburo
{
    internal interface ConsoleHandler
    {
        void PrintToConsole(string text);
        void ShowCompileError(int Line, string ErrorMessage);
    }
}
