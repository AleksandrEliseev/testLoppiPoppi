using System;
using Model;
using DependencyInjection;
using ExpressionModelData.Model;
using ExpressionResultView.View;
using Repository;
using UnityEngine;

namespace ExpressionResultView
{
    public class ResultViewPresenter : IDisposable
    {
        private readonly IResultView _view;
        private readonly IRepository _repository;
        private readonly IAdditionModelKeeper _modelKeeper;

        private const string History = "History";

        public ResultViewPresenter(IResultView view)
        {
            _view = view;
            _repository = ServiceLocator.Resolve<IRepository>();
            _modelKeeper = ServiceLocator.Resolve<IAdditionModelKeeper>();
            _modelKeeper.OnModelsChanged += AddResult;
            var history = _repository.LoadStringValue(AppConst.HISTORY_KEY);
            _modelKeeper.TryToLoadModels(history);
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
            string resultText = $"{model.Expression}={model.Result}";
            _view.AddResult(resultText);
            _view.UpdateScrollSize();
        }

        public void Dispose()
        {
            _modelKeeper.OnModelsChanged -= AddResult;
        }
    }
}