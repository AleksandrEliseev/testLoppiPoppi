using ExpressionModelData.Model;

namespace MathLogic
{
    public interface ICalculatorInteractor
    {
        BaseExpressionModel Calculate(string expression);
    }
}