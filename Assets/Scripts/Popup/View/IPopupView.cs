using System;

namespace Popup
{
    public interface IPopupView
    {
        void Show();
        void Hide();
        Action OnClose { get; set; }
    }
}