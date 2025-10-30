using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExpressionModelData.Parser
{
    public class ModelParser<T> : IModelParser<T>
    {
        public string ToJsonString(List<T> models)
        {
            var wrapper = new Wrapper<T> { Items = models };
            return JsonUtility.ToJson(wrapper);
        }

        public List<T> FromJsonString(string json)
        {
            if (string.IsNullOrEmpty(json))
                return new List<T>();

            var wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper?.Items ?? new List<T>();
        }

        [Serializable]
        private class Wrapper<U>
        {
            public List<U> Items = new();
        }
    }
}
