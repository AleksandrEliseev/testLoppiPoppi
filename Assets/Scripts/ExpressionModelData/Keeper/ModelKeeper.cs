using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ExpressionModelData.Model;
using ExpressionModelData.Parser;

namespace ExpressionModelData.Keeper 
{
    public class ModelKeeper<T> : IModelKeeper<T> where T : IExpressionModel
    {
        private readonly IModelParser<T> _parser;
        private List<T> _cachedModels = new List<T>();
     
        public event Action<T> OnModelsChanged;
        
        public ModelKeeper(IModelParser<T> parser)
        {
            _parser = parser;
        }
        public IReadOnlyCollection<T> GetAll()
        {
            return new ReadOnlyCollection<T>(_cachedModels);
        }
        public string ParseModels()
        {
            return _parser.ToJsonString(_cachedModels);
        }
        public void TryToLoadModels(string json)
        {
            if (_cachedModels != null) return;
            _cachedModels = string.IsNullOrEmpty(json) ? new List<T>() : _parser.FromJsonString(json);
        }
        public void AddModel(T model)
        {
            _cachedModels.Add(model);
            OnModelsChanged?.Invoke(model);
        }
    }
}