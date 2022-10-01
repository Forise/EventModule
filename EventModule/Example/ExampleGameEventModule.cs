using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using EventModule.Interfaces;

namespace EventModule.Example
{
#pragma warning disable CS1591
    public class ExampleGameEventModule : AEventModule
    {
        #region Observers
        public readonly EventObserver<ExampleEnum> exampleEventObserver = new EventObserver<ExampleEnum>();
        public readonly EventObserver<VarEnum> exampleEventObserver2 = new EventObserver<VarEnum>();
        /// <inheritdoc />
        public override ICollection<IEventObserver> Observers { get; protected set; }

        #endregion Observers

        #region IEventSubscribable implementation
        /// <inheritdoc />
        public override void SubscribeT<T>(T type, EventHandler<GameEventArgs<T>> handler)
        {
            if (Observers == null)
            {
                Observers = new List<IEventObserver>()
                {
                    exampleEventObserver,
                    exampleEventObserver2,
                };
            }
            var observer = Observers.ToList().Find(x => x.Type == typeof(T));
            if (observer != null)
            {
                observer.SubscribeT(type, handler);
            }
            else
            {
                Console.Error.WriteLine($"This kind of type {typeof(T)} is not supported by ExampleGameEventModule.");
            }
        }

        /// <inheritdoc />
        public override void UnsubscribeT<T>(T type, EventHandler<GameEventArgs<T>> handler)
        {
            var observer = Observers.ToList().Find(x => x.Type == typeof(T));

            if (observer != null)
            {
                observer.UnsubscribeT(type, handler);
            }
            else
            {
                Console.Error.WriteLine($"This kind of type {typeof(T)} is not supported by ExampleGameEventModule.");
            }
        }

        /// <inheritdoc />
        public override void UnsubscribeAllForObserver(IEventObserver observer)
        {
            observer.UnsubscribeAll();
        }

        /// <inheritdoc />
        public override void UnsubscribeAllForEnum<T>()
        {
            T s = default;
            switch (s)
            {
                case ExampleEnum a:
                    exampleEventObserver.UnsubscribeAll();
                    break;
                case VarEnum b:
                    exampleEventObserver2.UnsubscribeAll();
                    break;
                default:
                    Console.WriteLine($"This kind of type {typeof(T)} is not supported by ExampleGameEventModule.");
                    break;
            }
        }

        /// <inheritdoc />
        public override void UnsubscribeAll()
        {
            foreach (var eventObserver in Observers)
            {
                eventObserver.UnsubscribeAll();
            }
        }
        #endregion IEventSubscribable implementation

        #region IEventNotifier implementation
        /// <inheritdoc />
        public override void NotifyT<T>(object sender, GameEventArgs<T> eventArgs)
        {
            var observer = Observers.ToList().Find(x => x.Type == typeof(T));
            if (observer != null)
            {
                observer.NotifyT(sender, eventArgs);
            }
            else
            {
                Console.Error.WriteLine($"This kind of type {typeof(T)} is not supported by ExampleGameEventModule.");
            }
        }

        /// <inheritdoc />
        public override void NotifyT<T>(object sender, T type)
        {
            var observer = Observers.ToList().Find(x => x.Type == typeof(T));
            if (observer != null)
            {
                observer.NotifyT(sender, type);
            }
            else
            {
                Console.Error.WriteLine($"This kind of type {typeof(T)} is not supported by ExampleGameEventModule.");
            }
        }
        #endregion IEventNotifier implementation
    }
#pragma warning restore CS1591
}