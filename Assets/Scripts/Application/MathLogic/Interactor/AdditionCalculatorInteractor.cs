using DependencyInjection;
using ExpressionModelData.Model;

namespace MathLogic
{
    public class AdditionCalculatorInteractor : ICalculatorInteractor
    {
        private readonly IExpressionValidator _validator;

        public AdditionCalculatorInteractor()
        {
            _validator = ServiceLocator.Resolve<IExpressionValidator>();
        }

        public BaseExpressionModel Calculate(string expression)
        {
            if (!_validator.IsValid(expression))
                return new BaseExpressionModel(expression, "Error", false);

            var parts = expression.Split('+');
            if (int.TryParse(parts[0], out int left) &&
                int.TryParse(parts[1], out int right))
            {
                string result = (left + right).ToString();
                return new BaseExpressionModel(expression, result, true);
            }

            return new BaseExpressionModel(expression, "Error", false);
        }
    }
}