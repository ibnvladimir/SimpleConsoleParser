namespace Interfaces {
    interface ICodeChecker
    {
        bool CheckCodeSyntax(string source, string lang);
    }
}