using System;
using System.Collections;
using System.Collections.Generic;

namespace EventModule.Interfaces
{
    internal interface IEventModule : IEventNotifier, IEventSubscribable
    {
        /// <summary>
        /// Collection of observers. You MUST fill in this collections with all modules(event modules) which you are using.
        /// </summary>
        ICollection<IEventObserver> Observers { get; }
    }
}