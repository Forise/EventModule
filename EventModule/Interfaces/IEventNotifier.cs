using System;

namespace EventModule.Interfaces
{
    internal interface IEventNotifier<T> where T : Enum
    {
        void Notify(object sender, GameEventArgs<T> eventArgs);
        void Notify(object sender, T type);
    }
    
    /// <summary>
    /// Represents object which can notify event;
    /// </summary>
    public interface IEventNotifier
    {
        /// <summary>
        /// Notify observers with event and arguments method. 
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="eventArgs">event arguments (additional data)</param>
        /// <typeparam name="T">Enum with events; T : Enum</typeparam>
        void NotifyT<T>(object sender, GameEventArgs<T> eventArgs) where T : Enum;

        /// <summary>
        /// Notify observers with event method. 
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="type">Event(value/member) from Enum with events;</param>
        /// <typeparam name="T">Enum with events; T : Enum</typeparam>
        void NotifyT<T>(object sender, T type) where T : Enum;
    }
}