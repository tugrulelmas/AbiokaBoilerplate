﻿using AbiokaBoilerplate.Infrastructure.Common.IoC;
using System;
using System.Threading.Tasks;
using System.Reflection;

namespace AbiokaBoilerplate.Infrastructure.Common.Domain
{
    public class EventDispatcher : IEventDispatcher
    {
        public void Dispatch<T>(params T[] events) where T : IEvent {
            foreach (var eventItem in events) {
                if (eventItem == null)
                    throw new ArgumentNullException(nameof(eventItem), "Event can not be null.");

                var type = typeof(IEventHandler<>).MakeGenericType(eventItem.GetType());
                var handler = DependencyContainer.Container.Resolve(type);
                if (handler == null)
                    continue;

                var methodInfo = handler.GetType().GetMethod("Handle");
                methodInfo.Invoke(handler, new object[] { eventItem });

                //((dynamic)handler).Handle(eventItem);
            }
        }

        public async Task DispatchAsync<T>(params T[] events) where T : IEvent {
            await Task.Factory.StartNew(() => { Dispatch<T>(events); });
        }
    }
}
