using System;

namespace ExpressionModelData.Model
{
    [Serializable]
    public class BaseExpressionModel : IExpressionModel
    {
        public string Expression { get; private set; }
        public string Result{ get; private set; }
        public bool IsValid{ get; private set; }

        public BaseExpressionModel(string expression, string result,bool isValid)
        {
            Expression = expression;
            Result = result;
            IsValid = isValid;
        }
    }
}