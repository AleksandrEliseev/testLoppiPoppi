using System;
using System.Collections.Generic;

namespace Popup.Keeper
{
    public class PopupKeeper : IPopupKeeper
    {
        private readonly Dictionary<Type, IPopupView> _popups = new();

        public void Add<T>(T popup) where T : IPopupView
        {
            var type = typeof(T);
            if (!_popups.ContainsKey(type))
                _popups[type] = popup;
        }

        public bool TryGet<T>(out T popup) where T : IPopupView
        {
            if (_popups.TryGetValue(typeof(T), out var screen))
            {
                popup = (T)screen;
                return true;
            }

            popup = default;
            return false;
        }
    }
}