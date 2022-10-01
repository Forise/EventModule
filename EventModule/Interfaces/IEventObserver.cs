using System;

namespace EventModule.Interfaces
{
    /// <summary>
    /// Observer interface
    /// </summary>
    public interface IEventObserver : IEventNotifier, IEventSubscribable
    {
        /// <summary>
        /// Enum type with events
        /// </summary>
        Type Type { get; }
    }
}