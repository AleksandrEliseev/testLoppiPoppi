using System;
using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CalculatorPanel.View
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _resultButton;

        public event Action<string> OnInputTextChanged;
        public event Action<string> OnResultButtonClicked;

        private Coroutine _selectCoroutine;
        private void Start()
        {
            SelectInputField(5);
        }

        public void ClearInputField()
        {
            _inputField.text = string.Empty;
            SelectInputField();
        }

        public void SetExpressionText(string expression)
        {
            if (!string.IsNullOrEmpty(expression))
                _inputField.SetTextWithoutNotify(expression);
            SelectInputField();
        }

        private void SelectInputField(int frameCount =1)
        {
            TryToStopSelectCoroutine();
            _selectCoroutine = StartCoroutine(DelayedSelect(frameCount));
        }

        private void TryToStopSelectCoroutine()
        {
            if (_selectCoroutine != null)
            {
                StopCoroutine(_selectCoroutine);
                _selectCoroutine = null;
            }
        }
        private IEnumerator DelayedSelect(int delayFrame = 1)
        {
            int frameCount=0;
            while (frameCount<delayFrame)
            {
                frameCount++;
                yield return null;
            }
            _inputField.ActivateInputField();
        }

        public void Show()
        {
            _canvas.enabled = true;
            SelectInputField();
        }
        public void Hide()
        {
            _canvas.enabled = false;
        }

        private void ResultButtonClicked()
        {
            OnResultButtonClicked?.Invoke(_inputField.text);
        }
        private void InputFieldChanged(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                char lastChar = input[^1]; // last symbol
                if (!Regex.IsMatch(lastChar.ToString(), @"[0-9+\-*/().]"))
                {
                    string corrected = input.Substring(0, input.Length - 1);
                    _inputField.text = corrected;
                }
            }

            OnInputTextChanged?.Invoke(_inputField.text);
        }

        private void OnEnable()
        {
            _resultButton.onClick.AddListener(ResultButtonClicked);
            _inputField.onValueChanged.AddListener(InputFieldChanged);
        }
        private void OnDisable()
        {
            _resultButton.onClick.RemoveListener(ResultButtonClicked);
            _inputField.onValueChanged.RemoveListener(InputFieldChanged);
            TryToStopSelectCoroutine();
        }
    }
}