using System;
using UnityEngine;

namespace ExpressionModelData.Model
{
    [Serializable]
    public class BaseExpressionModel : IExpressionModel
    {
        [field: SerializeField]
        public string Expression { get; private set; }
        [field: SerializeField]
        public string Result{ get; private set; }
        [field: SerializeField]
        public bool IsValid{ get; private set; }

        public BaseExpressionModel(string expression, string result,bool isValid)
        {
            Expression = expression;
            Result = result;
            IsValid = isValid;
        }
    }
}