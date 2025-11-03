using System.Text.RegularExpressions;

namespace MathLogic
{
    public class AdditionExpressionValidator : IExpressionValidator
    {
        public bool IsValid(string expression)
        {
            return Regex.IsMatch(expression, @"^\d{1,}\+\d{1,}$");
        }
    }
}