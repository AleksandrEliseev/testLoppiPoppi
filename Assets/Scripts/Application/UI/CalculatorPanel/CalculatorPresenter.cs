using System;
using CalculatorPanel.View;
using Model;
using MathLogic;
using DependencyInjection;
using Popup;
using ExpressionModelData.Model;
using Repository;
using UnityEngine;

namespace CalculatorPanel
{
    public class CalculatorPresenter : IDisposable
    {
        private readonly ICalculatorView _view;
        private readonly IRepository _repository;
        private readonly ICalculatorInteractor _calculatorInteractor;
        private readonly IMainPopupService _popupService;
        private readonly IAdditionModelKeeper _modelKeeper;


        public CalculatorPresenter(ICalculatorView view)
        {
            _view = view;

            _repository = ServiceLocator.Resolve<IRepository>();
            _calculatorInteractor = ServiceLocator.Resolve<ICalculatorInteractor>();
            _popupService = ServiceLocator.Resolve<IMainPopupService>();
            _modelKeeper = ServiceLocator.Resolve<IAdditionModelKeeper>();

            _view.OnResultButtonClicked += HandleResultButtonClicked;
            _view.OnInputTextChanged += HandleInputTextChanged;

            _view.SetExpressionText(_repository.LoadStringValue(AppConst.LAST_INPUT_KEY));
        }
        private void HandleInputTextChanged(string expression)
        {
            _repository.SaveStringValue(AppConst.LAST_INPUT_KEY, expression);
        }
        private void HandleResultButtonClicked(string expression)
        {
            BaseExpressionModel model = _calculatorInteractor.Calculate(expression);
            if (model.IsValid)
            {
                _view.ClearInputField();
            }
            else
            {
                _view.Hide();
                _popupService.Show<IMessagePopupView>((popup) =>
                {
                    string messageText = "Please check the expression you just entered";
                    popup.SetMessage(messageText);
                    popup.OnClose += () =>
                    {
                        _view.Show();
                        popup.OnClose = null;
                    };
                });
            }

            _modelKeeper.AddModel(model);
            SaveHistory();
        }
        private void SaveHistory()
        {
            string saveHistory = _modelKeeper.ParseModels();
            _repository.SaveStringValue(AppConst.HISTORY_KEY, saveHistory);
        }

        public void Dispose()
        {
            _view.OnResultButtonClicked -= HandleResultButtonClicked;
            _view.OnInputTextChanged -= HandleInputTextChanged;
        }
    }
}