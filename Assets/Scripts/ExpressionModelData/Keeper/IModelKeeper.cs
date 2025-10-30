using System;
using System.Collections.Generic;

namespace ExpressionModelData.Keeper 
{
    public interface IModelKeeper<T>
    {
        void TryToLoadModels(string json);
        IReadOnlyCollection<T> GetAll();
        void AddModel(T model);
        string ParseModels();

        event Action<T> OnModelsChanged;
    }
}