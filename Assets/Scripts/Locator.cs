using System;
using System.Collections.Generic;

namespace ProductionReady
{
    public class Locator : ILocator
    {
        private readonly Dictionary<Type, object> _bindings;

        public Locator()
        {
            _bindings = new Dictionary<Type, object>();
        }

        public TBindingType Get<TBindingType>()
        {
            return (TBindingType) _bindings.GetValueOrDefault(typeof(TBindingType));
        }

        public void Bind<TBindingType>(TBindingType instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (_bindings.TryGetValue(typeof(TBindingType), out object existingInstance))
            {
                throw new Exception($"Type {typeof(TBindingType)} already bound to instance {existingInstance}! Unbind before binding a new instance!");
            }
            
            _bindings.Add(typeof(TBindingType), instance);
        }

        public void Unbind<TBindingType>()
        {
            if (_bindings.TryGetValue(typeof(TBindingType), out object instance))
            {
                DisposeInstance(instance);
                _bindings.Remove(typeof(TBindingType));
            }
        }

        private void DisposeInstance(object instance)
        {
            if (instance is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}