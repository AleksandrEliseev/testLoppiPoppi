namespace ExpressionModelData.Model
{
    public interface IExpressionModel
    {
        string Expression { get; }
        string Result { get; }
        bool IsValid { get; }
    }
}