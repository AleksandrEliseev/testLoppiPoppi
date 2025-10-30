using ExpressionModelData.Keeper;
using ExpressionModelData.Model;
using ExpressionModelData.Parser;

namespace Model
{
    public interface IAdditionModelKeeper : IModelKeeper<BaseExpressionModel> { }

    public class AdditionModelKeeper : ModelKeeper<BaseExpressionModel>, IAdditionModelKeeper
    {
        public AdditionModelKeeper() : base(new ModelParser<BaseExpressionModel>())
        {
        }
    }

}