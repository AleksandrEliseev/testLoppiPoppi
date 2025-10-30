using System;

namespace CalculatorPanel.View
{
    public interface ICalculatorView
    {
        event Action<string> OnInputTextChanged;
        event Action<string> OnResultButtonClicked;
        void ClearInputField();
        void SetExpressionText(string expression);
        void Show();
        void Hide();
    }
}