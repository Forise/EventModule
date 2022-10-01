using System;
using System.Collections.Generic;
using EventModule.Interfaces;

namespace EventModule
{
    /// <summary>
    /// Represents observer of events by enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventObserver<T> : IEventObserver, IEventNotifier<T>, IEventSubscribeHolder<T> where T : Enum
    {
        /// <inheritdoc />
        public Type Type => typeof(T);
        
        /// <inheritdoc />
        public Dictionary<T, HashSet<EventHandler<GameEventArgs<T>>>> Subscribes { get; private set; } =
            new Dictionary<T, HashSet<EventHandler<GameEventArgs<T>>>>();

        /// <inheritdoc />
        public void Notify(object sender, GameEventArgs<T> eventArgs)
        {
            if (Subscribes.ContainsKey(eventArgs.type))
            {
                HashSet<EventHandler<GameEventArgs<T>>> handlers = new HashSet<EventHandler<GameEventArgs<T>>>(Subscribes[eventArgs.type]);
                foreach (var handler in handlers)
                {
                    handler(sender, eventArgs);
                }
            }
        }

        /// <inheritdoc />
        public void Notify(object sender, T type)
        {
            if (Subscribes.ContainsKey(type))
            {
                HashSet<EventHandler<GameEventArgs<T>>> handlers = new HashSet<EventHandler<GameEventArgs<T>>>(Subscribes[type]);
                foreach (var handler in handlers)
                {
                    handler(sender, new GameEventArgs<T>(type));
                }
            }
        }

        /// <inheritdoc />
        public void Subscribe(T type, EventHandler<GameEventArgs<T>> handler)
        {
            if (!Subscribes.ContainsKey(type))
            {
                Subscribes.Add(type, new HashSet<EventHandler<GameEventArgs<T>>>());
            }

            if (!Subscribes[type].Contains(handler))
            {
                Subscribes[type].Add(handler);
            }
        }

        /// <inheritdoc />
        public void Unsubscribe(T type, EventHandler<GameEventArgs<T>> handler)
        {
            if (type != null && Subscribes.ContainsKey(type) && Subscribes[type].Contains(handler))
            {
                Subscribes[type].Remove(handler);
                if (Subscribes[type].Count == 0)
                {
                    Subscribes.Remove(type);
                }
            }
        }

        /// <inheritdoc cref="IEventSubscribable.UnsubscribeAll" />
        public void UnsubscribeAll()
        {
            Subscribes.Clear();
        }

        /// <inheritdoc />
        public void NotifyT<T1>(object sender, GameEventArgs<T1> eventArgs) where T1 : Enum
        {
            Notify(sender, eventArgs as GameEventArgs<T>);
        }

        /// <inheritdoc />
        public void NotifyT<T1>(object sender, T1 type) where T1 : Enum
        {
            Notify(sender, type is T @enum ? @enum : default);
        }

        /// <inheritdoc />
        public void SubscribeT<T1>(T1 type, EventHandler<GameEventArgs<T1>> handler) where T1 : Enum
        {
            Subscribe(type is T @enum ? @enum : default, handler as EventHandler<GameEventArgs<T>>);
        }

        /// <inheritdoc />
        public void UnsubscribeT<T1>(T1 type, EventHandler<GameEventArgs<T1>> handler) where T1 : Enum
        {
            Unsubscribe(type is T @enum ? @enum : default, handler as EventHandler<GameEventArgs<T>>);
        }
    }
}