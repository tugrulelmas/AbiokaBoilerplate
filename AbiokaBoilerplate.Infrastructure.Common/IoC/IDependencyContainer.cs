﻿using System;
using System.Collections.Generic;

namespace AbiokaBoilerplate.Infrastructure.Common.IoC
{
    public interface IDependencyContainer : IDisposable
    {
        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();

        /// <summary>
        /// Resolves all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> ResolveAll<T>();

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// Registers the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        IDependencyContainer Register<T>(LifeStyle lifeStyle, bool isFallback = false);

        /// <summary>
        /// Registers the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        IDependencyContainer Register(Type type, LifeStyle lifeStyle, bool isFallback = false);
       
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <returns></returns>
        IDependencyContainer RegisterServices<T1, T2>();

        /// <summary>
        /// Registers the service.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        IDependencyContainer RegisterService<T1, T2>(LifeStyle lifeStyle = LifeStyle.Singleton);

        /// <summary>
        /// Registers the with default interfaces.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <returns></returns>
        IDependencyContainer RegisterWithDefaultInterfaces<T1, T2>();

        /// <summary>
        /// Registers the with default interfaces.
        /// </summary>
        /// <param name="type1">The type1.</param>
        /// <param name="type2">The type2.</param>
        /// <returns></returns>
        IDependencyContainer RegisterWithDefaultInterfaces(Type type1, Type type2);

        /// <summary>
        /// Registers the with base.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <returns></returns>
        IDependencyContainer RegisterWithBase<T1, T2>();

        /// <summary>
        /// Registers the with base.
        /// </summary>
        /// <param name="type1">The type1.</param>
        /// <param name="type2">The type2.</param>
        /// <returns></returns>
        IDependencyContainer RegisterWithBase(Type type1, Type type2);

        /// <summary>
        /// Registers the specified type.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        IDependencyContainer Register<T1, T2>(LifeStyle lifeStyle = LifeStyle.Singleton, bool isFallback = false);

        /// <summary>
        /// Registers the specified type1.
        /// </summary>
        /// <param name="type1">The type1.</param>
        /// <param name="type2">The type2.</param>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        IDependencyContainer Register(Type type1, Type type2, LifeStyle lifeStyle = LifeStyle.Singleton, bool isFallback = false);
    }
}
