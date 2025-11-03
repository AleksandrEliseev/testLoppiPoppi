using System;
using Popup.Keeper;
using UnityEngine;

namespace Popup.Service
{
    public class PopupService: IPopupService
    {
        private readonly IPopupKeeper _popupKeeper;

        public PopupService(IPopupKeeper popupKeeper)
        {
            _popupKeeper = popupKeeper;
        }
        
        public void Register<T>(T popup) where T : IPopupView
        {
            _popupKeeper.Add(popup);
        }
        
        public void Show<T>(Action<T> preShowAction = null) where T : IPopupView
        {
            if (_popupKeeper.TryGet(out T popup))
            {
                preShowAction?.Invoke(popup);
                popup.Show();
            }
            else
            {
                Debug.LogError($"Popup of type {typeof(T).Name} not registered.");
            }
        }

        public void Hide<T>() where T : IPopupView
        {
            if (_popupKeeper.TryGet(out T popup))
            {
                popup.Hide();
            }
        }
    }
}