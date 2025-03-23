using System;
using Unity;
using Unity.Lifetime;
using IncidentManagement.Data.Repositories;
using IncidentManagement.Services.Interfaces;
using IncidentManagement.Services.Services;

namespace IncidentManagement.Web
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new HierarchicalLifetimeManager());
            container.RegisterType<IIncidentService, IncidentService>(new HierarchicalLifetimeManager());
        }
    }
} 