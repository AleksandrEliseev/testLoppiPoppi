using System.Collections.Generic;

namespace ExpressionModelData.Parser
{
    public interface IModelParser<T>
    {
        string ToJsonString(List<T> models);
        List<T> FromJsonString(string json);
    }

}