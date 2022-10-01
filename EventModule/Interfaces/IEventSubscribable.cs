using System;
using System.Collections.Generic;

namespace EventModule.Interfaces
{
    internal interface IEventSubscribable<T> where T : Enum
    {
        void Subscribe(T type, EventHandler<GameEventArgs<T>> handler);
        void Unsubscribe(T type, EventHandler<GameEventArgs<T>> handler);
        void UnsubscribeAll();
    }
    
    /// <summary>
    /// Represent object which can subscribe/unsubscribe for event;
    /// </summary>
    public interface IEventSubscribable
    {
        /// <summary>
        /// Subscribe handler to event with type 'type'. 
        /// </summary>
        /// <param name="type">Event(value/member) from Enum with events;</param>
        /// <param name="handler">Handler method/delegate with event arguments (additional data)</param>
        /// <typeparam name="T">Enum with events; T : Enum</typeparam>
        void SubscribeT<T>(T type, EventHandler<GameEventArgs<T>> handler) where T : Enum;
        /// <summary>
        /// Unsubscribe handler from event with type 'type'. 
        /// </summary>
        /// <param name="type">Event(value/member) from Enum with events;</param>
        /// <param name="handler">Handler method/delegate with event arguments (additional data)</param>
        /// <typeparam name="T">Enum with events; T : Enum</typeparam>
        void UnsubscribeT<T>(T type, EventHandler<GameEventArgs<T>> handler) where T : Enum;
        /// <summary>
        /// Unsubscribes all events
        /// </summary>
        void UnsubscribeAll();
    }
    
    internal interface IEventSubscribeHolder<T> : IEventSubscribable<T> where T : Enum
    {
        /// <summary>
        /// Represents hashset of subscribed handlers by ENUM_WITH_EVENTS key;
        /// Dictionary of (ENUM_WITH_EVENTS, HashSet[EventHandler[GameEventArgs[T]]]);
        /// </summary>
        Dictionary<T, HashSet<EventHandler<GameEventArgs<T>>>> Subscribes { get; }
    }
}