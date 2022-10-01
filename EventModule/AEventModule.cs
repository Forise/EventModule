using System;
using System.Collections.Generic;
using EventModule.Interfaces;
using UnityEngine;

namespace EventModule
{
    /// <summary>
    /// Base abstract class for EventModule.
    /// </summary>
    public abstract class AEventModule : IEventModule
    {
        #region IEventSubscribable implementation
        /// <inheritdoc />
        public abstract ICollection<IEventObserver> Observers { get; protected set; }

        /// <summary>
        /// Subscribes one enum element to event handler
        /// </summary>
        /// <param name="type">Enum element</param>
        /// <param name="handler">Handler method</param>
        /// <typeparam name="T">Enum type</typeparam>
        public abstract void SubscribeT<T>(T type, EventHandler<GameEventArgs<T>> handler) where T : Enum;

        /// <summary>
        /// Subscribes all T enum members to handler
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        public void SubscribeRange<TEnum>(ICollection<TEnum> types, EventHandler<GameEventArgs<TEnum>> handler) where TEnum : Enum
        {
            if (types != null && types.Count > 0)
            {
                foreach (var type in types)
                {
                    SubscribeT(type, handler);
                }            
            }
            else
            {
                Debug.LogError($"There are not any elements in enum {typeof(TEnum)}");
                Console.Error.WriteLine($"There are not any elements in enum {typeof(TEnum)}");
            }
        }
        
        /// <summary>
        /// Subscribes all T enum members to handler
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        public void SubscribeRange<TEnum>(EventHandler<GameEventArgs<TEnum>> handler) where TEnum : Enum
        {
            var types = Enum.GetValues(typeof(TEnum)) as TEnum[];
            SubscribeRange(types, handler);
        }
        
        /// <summary>
        /// Unsubscribes one enum element to event handler
        /// </summary>
        /// <param name="type">Enum element</param>
        /// <param name="handler">Handler method</param>
        /// <typeparam name="T">Enum type</typeparam>
        public abstract void UnsubscribeT<T>(T type, EventHandler<GameEventArgs<T>> handler) where T : Enum;

        /// <summary>
        /// Unsubscribes everything from observer
        /// </summary>
        public abstract void UnsubscribeAllForObserver(IEventObserver observer);

        /// <summary>
        /// Unsubscribes everything for EnumType
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract void UnsubscribeAllForEnum<T>() where T : Enum;

        /// <summary>
        /// Unsubscribes everything for all observers
        /// </summary>
        public abstract void UnsubscribeAll();
        #endregion IEventSubscribable implementation

        #region IEventNotifier implementation
        /// <summary>
        /// Notifies Event with type T and event args
        /// </summary>
        /// <param name="sender">Object which notified event</param>
        /// <param name="eventArgs">Arguments/additional data for event</param>
        /// <typeparam name="T">Enum type</typeparam>
        public abstract void NotifyT<T>(object sender, GameEventArgs<T> eventArgs) where T : Enum;

        /// <summary>
        /// Notifies Event with type T and event args
        /// </summary>
        /// <param name="sender">Object which notified event</param>
        /// <param name="type">Enum member. Event type</param>
        /// <typeparam name="T">Enum type</typeparam>
        public abstract void NotifyT<T>(object sender, T type) where T : Enum;
        #endregion IEventNotifier implementation
    }
    
    /// <summary>
    /// Base abstract class for EventModule as MonoBehaviour.
    /// </summary>
    public abstract class AEventModuleMono : MonoBehaviour, IEventModule
    {
        /// <inheritdoc />
        public abstract ICollection<IEventObserver> Observers { get; }

        #region IEventSubscribable implementation
        /// <summary>
        /// Subscribes one enum element to event handler
        /// </summary>
        /// <param name="type">Enum element</param>
        /// <param name="handler">Handler method</param>
        /// <typeparam name="T">Enum type</typeparam>
        public abstract void SubscribeT<T>(T type, EventHandler<GameEventArgs<T>> handler) where T : Enum;

        /// <summary>
        /// Subscribes all T enum members to handler
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        public void SubscribeRange<TEnum>(ICollection<TEnum> types, EventHandler<GameEventArgs<TEnum>> handler) where TEnum : Enum
        {
            if (types != null && types.Count > 0)
            {
                foreach (var type in types)
                {
                    SubscribeT(type, handler);
                }            
            }
            else
            {
                Debug.LogError($"There are not any elements in enum {typeof(TEnum)}");
                Console.Error.WriteLine($"There are not any elements in enum {typeof(TEnum)}");
            }
        }
        
        /// <summary>
        /// Subscribes all T enum members to handler
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        public void SubscribeRange<TEnum>(EventHandler<GameEventArgs<TEnum>> handler) where TEnum : Enum
        {
            var types = Enum.GetValues(typeof(TEnum)) as TEnum[];
            SubscribeRange(types, handler);
        }
        
        /// <summary>
        /// Unsubscribes one enum element to event handler
        /// </summary>
        /// <param name="type">Enum element</param>
        /// <param name="handler">Handler method</param>
        /// <typeparam name="T">Enum type</typeparam>
        public abstract void UnsubscribeT<T>(T type, EventHandler<GameEventArgs<T>> handler) where T : Enum;

        /// <summary>
        /// Unsubscribes everything from observer
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        public abstract void UnsubscribeAllForObserver<T>(EventObserver<T> observer) where T : Enum;

        /// <summary>
        /// Unsubscribes everything for EnumType
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract void UnsubscribeAllForEnum<T>() where T : Enum;

        /// <summary>
        /// Unsubscribes everything for all observers
        /// </summary>
        public abstract void UnsubscribeAll();
        #endregion IEventSubscribable implementation

        #region IEventNotifier implementation
        /// <summary>
        /// Notifies Event with type T and event args
        /// </summary>
        /// <param name="sender">Object which notified event</param>
        /// <param name="eventArgs">Arguments/additional data for event</param>
        /// <typeparam name="T">Enum type</typeparam>
        public abstract void NotifyT<T>(object sender, GameEventArgs<T> eventArgs) where T : Enum;

        /// <summary>
        /// Notifies Event with type T and event args
        /// </summary>
        /// <param name="sender">Object which notified event</param>
        /// <param name="type">Enum member. Event type</param>
        /// <typeparam name="T">Enum type</typeparam>
        public abstract void NotifyT<T>(object sender, T type) where T : Enum;
        #endregion IEventNotifier implementation
    }
}