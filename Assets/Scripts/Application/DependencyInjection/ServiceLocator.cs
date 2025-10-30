using System;
using System.Collections.Generic;

namespace DependencyInjection
{
    public class ServiceLocator 
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<T>(T service)
        {
            var type = typeof(T);
            if (_services.ContainsKey(type))
                throw new InvalidOperationException($"Service of type {type} is already registered.");

            _services[type] = service;
        }

        public static T Resolve<T>()
        {
            var type = typeof(T);
            if (_services.TryGetValue(type, out var service))
                return (T)service;

            throw new InvalidOperationException($"Service of type {type} is not registered.");
        }
    }
}