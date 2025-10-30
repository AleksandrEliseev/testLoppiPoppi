using System.Text.RegularExpressions;

namespace MathLogic
{
    public class AdditionExpressionValidator : IExpressionValidator
    {
        public  bool IsValid(string expression)
        {
            if (string.IsNullOrEmpty(expression) || expression.Contains(" "))
                return false;
            
            return Regex.IsMatch(expression, @"^\d+\+\d+$");
        }
    }
}