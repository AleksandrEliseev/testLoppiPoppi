using CalculatorPanel;
using CalculatorPanel.View;
using DependencyInjection;
using ExpressionResultView;
using ExpressionResultView.View;
using Popup;
using UnityEngine;

namespace Model
{
    public class ScreenInstaller : MonoBehaviour
    {
        [SerializeField] private MessagePopupView _messagePopupView;
        [SerializeField] private CalculatorView _calculatorView;
        [SerializeField] private ResultView _resultView;
        private void Start()
        {
            //popup registration
            IMainPopupService popupService = ServiceLocator.Resolve<IMainPopupService>();
            popupService.Register<IMessagePopupView>(_messagePopupView);
            //screen registration
            new CalculatorPresenter(_calculatorView);
            new ResultViewPresenter(_resultView);
        }
    }
}