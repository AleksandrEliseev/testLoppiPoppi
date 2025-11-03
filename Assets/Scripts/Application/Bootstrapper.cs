using MathLogic;
using DependencyInjection;
using Repository;
using UnityEngine;

namespace Model
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.Register<IExpressionValidator>(new AdditionExpressionValidator());
            ServiceLocator.Register<ICalculatorInteractor>(new AdditionCalculatorInteractor());
            ServiceLocator.Register<IAdditionModelKeeper>(new AdditionModelKeeper());
            ServiceLocator.Register<IMainPopupService>(new MainPopupService());
            ServiceLocator.Register<IRepository>(new PlayerRepository());
        }
    }
}
