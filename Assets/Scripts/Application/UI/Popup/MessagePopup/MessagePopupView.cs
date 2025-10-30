using System;
using Popup.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Popup
{
    public class MessagePopupView : ABasePopup, IMessagePopupView
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _messageText;

        public Action OnClose { get; set; }

        private void Start()
        {
            Hide();
        }
        public override void Show()
        {
            _canvas.enabled = true;
        }
        public override void Hide()
        {
            _canvas.enabled = false;
            OnClose?.Invoke();
        }

        public void SetMessage(string text)
        {
            _messageText.text = text;
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Hide);
        }
        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Hide);
        }
    }
}