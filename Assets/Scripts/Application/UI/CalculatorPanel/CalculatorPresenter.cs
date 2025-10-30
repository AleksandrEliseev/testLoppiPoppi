using System;
using CalculatorPanel.View;
using Model;
using MathLogic;
using DependencyInjection;
using Popup;
using ExpressionModelData.Model;
using Repository;

namespace CalculatorPanel
{
    public class CalculatorPresenter : IDisposable
    {
        private readonly ICalculatorView _view;
        private readonly IRepository _resultRepository;
        private readonly ICalculatorInteractor _calculatorInteractor;
        private readonly IMainPopupService _popupService;
        private readonly IAdditionModelKeeper _modelKeeper;

        private const string LastInputKey = "LastInput";
        public CalculatorPresenter(ICalculatorView view)
        {
            _view = view;
            
            _resultRepository = ServiceLocator.Resolve<IRepository>();
            _calculatorInteractor = ServiceLocator.Resolve<ICalculatorInteractor>();
            _popupService = ServiceLocator.Resolve<IMainPopupService>();
            _modelKeeper = ServiceLocator.Resolve<IAdditionModelKeeper>();

            _view.OnResultButtonClicked += HandleResultButtonClicked;
            _view.OnInputTextChanged += HandleInputTextChanged;

            _view.SetExpressionText(_resultRepository.LoadStringValue(LastInputKey));
        }
        private void HandleInputTextChanged(string expression)
        {
            _resultRepository.SaveStringValue(expression, LastInputKey);
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
        }

        public void Dispose()
        {
            _view.OnResultButtonClicked -= HandleResultButtonClicked;
            _view.OnInputTextChanged -= HandleInputTextChanged;

            string saveHistory = _modelKeeper.ParseModels();
            _resultRepository.SaveStringValue(saveHistory, "History");
        }
    }
}