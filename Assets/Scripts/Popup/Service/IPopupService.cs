using System;

namespace Popup.Service
{
    public interface IPopupService
    {
        void Register<T>(T popup) where T : IPopupView;
        void Show<T>(Action<T> preShowAction = null) where T : IPopupView;
        void Hide<T>() where T : IPopupView;

    }
}