using System;
using System.Collections.Generic;

namespace SnowGame
{
    public abstract class ServiceLocatorBase : ISeviceLocator
    {
        protected IDictionary<Type, IService> _services;

        internal ServiceLocatorBase()
        {
            _services = new Dictionary<Type, IService>();
        }

        public T GetService<T>()
        {
            try
            {
                return (T)_services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("Service " + typeof(T) + " is not registered!");
            }
        }

        protected void AddService<T>(IService service)
        {
            if (service is T)
            {
                _services.Add(typeof(T), service);

            }
            else
            {
                throw new Exception("Service " + service.ToString() + " have not implemented interface: " + typeof(T));
            }
        }

        public void InitServices()
        {
            foreach (IService service in _services.Values)
                service.Init();
        }

        public void Update()
        {
            foreach (IService service in _services.Values)
                service.Update();
        }

        public virtual void Dispose()
        {
            foreach (IService service in _services.Values)
                service.Dispose();
        }
    }
}