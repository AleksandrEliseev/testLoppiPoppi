using System;
using Model;
using DependencyInjection;
using ExpressionModelData.Model;
using ExpressionResultView.View;

namespace ExpressionResultView
{
    public class ResultViewPresenter : IDisposable
    {
        private readonly IResultView _view;
        private readonly IAdditionModelKeeper _modelKeeper;
        
        public ResultViewPresenter(IResultView view)
        {
            _view = view;
            _modelKeeper = ServiceLocator.Resolve<IAdditionModelKeeper>();
            _modelKeeper.OnModelsChanged += AddResult;
            LoadResults();
        }
        private void LoadResults()
        {
            foreach (var model in _modelKeeper.GetAll())
            {
                AddResult(model);
            }
            _view.UpdateScrollSize();
        }
        private void AddResult(BaseExpressionModel model)
        {
            string resultText= $"{model.Expression}={model.Result}";
            _view.AddResult(resultText);
            _view.UpdateScrollSize();
        }
        
        public void Dispose()
        {
            
        }
    }
}