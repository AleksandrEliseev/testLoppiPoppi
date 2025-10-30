namespace Popup.Keeper
{
    public interface IPopupKeeper
    {
        void Add<T>(T popup) where T : IPopupView;
        bool TryGet<T>(out T popup) where T : IPopupView;
    }
}