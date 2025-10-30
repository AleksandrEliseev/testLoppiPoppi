using Popup.Keeper;
using Popup.Service;

namespace Model
{
    public interface IMainPopupService : IPopupService
    {
        
    }
    
    public class MainPopupService : PopupService, IMainPopupService
    {
        public MainPopupService() : base(new PopupKeeper())
        {
        }
    }
}