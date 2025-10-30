using System;
using UnityEngine;

namespace Popup.View
{
    public abstract class ABasePopup : MonoBehaviour,IPopupView
    {
        public abstract void Show();
        public abstract void Hide();
        public Action OnClose { get; set; }
    }
}