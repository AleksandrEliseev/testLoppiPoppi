using Popup;

namespace Popup
{
    public interface IMessagePopupView : IPopupView
    {
        void SetMessage(string text);
    }
}

