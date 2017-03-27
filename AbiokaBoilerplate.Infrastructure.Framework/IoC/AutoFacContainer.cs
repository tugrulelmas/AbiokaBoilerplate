using AbiokaBoilerplate.Infrastructure.Common.IoC;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Core.Registration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AbiokaBoilerplate.Infrastructure.Framework.IoC
{
    public class AutoFacContainer : IDependencyContainer, IServiceProvider
    {
        public IContainer Container { get; private set; }

        public ContainerBuilder ContainerBuilder { get; private set; }

        public AutoFacContainer()
        {
            ContainerBuilder = new ContainerBuilder();
        }

        public void Build()
        {
            Container = ContainerBuilder.Build();
        }

        public void Dispose()
        {
            Container.Dispose();
        }

        public IDependencyContainer Register<T>(LifeStyle lifeStyle, bool isFallback = false)
        {
            ContainerBuilder.RegisterType<T>().AddLifeTime(lifeStyle);
            return this;
        }

        public IDependencyContainer Register(Type type, LifeStyle lifeStyle, bool isFallback = false)
        {
            ContainerBuilder.RegisterType(type).AddLifeTime(lifeStyle);
            return this;
        }

        public IDependencyContainer Register<T1, T2>(LifeStyle lifeStyle = LifeStyle.Singleton, bool isFallback = false)
        {
            ContainerBuilder.RegisterType<T2>().As<T1>().AddLifeTime(lifeStyle);
            return this;
        }

        public IDependencyContainer Register(Type type1, Type type2, LifeStyle lifeStyle = LifeStyle.Singleton, bool isFallback = false)
        {
            ContainerBuilder.RegisterType(type2).As(type1).AddLifeTime(lifeStyle);
            return this;
        }

        public IDependencyContainer RegisterService<T1, T2>(LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            ContainerBuilder.RegisterType<T2>().As<T1>().AddLifeTime(lifeStyle);
            return this;
        }

        public IDependencyContainer RegisterServices<T1, T2>()
        {
            ContainerBuilder.RegisterAssemblyTypes(typeof(T2).GetTypeInfo().Assembly)
                   .AssignableTo(typeof(T1)).AsImplementedInterfaces().SingleInstance();
            return this;
        }

        public IDependencyContainer RegisterWithBase<T1, T2>()
        {
            throw new NotImplementedException();
        }

        public IDependencyContainer RegisterWithBase(Type type1, Type type2)
        {
            throw new NotImplementedException();
        }

        public IDependencyContainer RegisterWithDefaultInterfaces<T1, T2>()
        {
            return RegisterWithDefaultInterfaces(typeof(T1), typeof(T2));
        }

        public IDependencyContainer RegisterWithDefaultInterfaces(Type type1, Type type2)
        {
            ContainerBuilder.RegisterAssemblyTypes(type2.GetTypeInfo().Assembly)
                   .AsClosedTypesOf(type1).AsImplementedInterfaces().SingleInstance();
            return this;
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return Container.Resolve(type);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return Container.Resolve<IEnumerable<T>>();
        }

        public object GetService(Type serviceType)
        {
            return Resolve(serviceType);
        }
    }

    public static class AutoFacContainerExtensions
    {
        public static IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> AddLifeTime<T>(this IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle> builder, LifeStyle lifeStyle)
        {
            if (lifeStyle == LifeStyle.PerWebRequest)
            {
                return builder.InstancePerLifetimeScope();
            }

            if (lifeStyle == LifeStyle.Transient)
            {
                return builder.InstancePerDependency();
            }

            return builder.SingleInstance();
        }
    }
}
