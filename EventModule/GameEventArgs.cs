using System;

namespace EventModule
{
    /// <summary>
    /// Arguments for event class container
    /// </summary>
    /// <typeparam name="T">Enum</typeparam>
    [Serializable]
    public class GameEventArgs<T> : EventArgs where T : Enum
    {
        /// <summary>
        /// Event type - value from Enum T
        /// </summary>
        public T type;
        /// <summary>
        /// string parameter
        /// </summary>
        public string str;
        /// <summary>
        /// int parameter
        /// </summary>
        public int? intParam;
        /// <summary>
        /// float parameter
        /// </summary>
        public float? floatParam;
        /// <summary>
        /// bool parameter
        /// </summary>
        public bool boolParam;
        /// <summary>
        /// object parameter
        /// </summary>
        public object objectParam;
        /// <summary>
        /// Action parameter - for confirmation/positive actions
        /// </summary>
        public Action okAction;
        /// <summary>
        /// Action parameter - for negative response actions
        /// </summary>
        public Action cancelAction;
        
#pragma warning disable CS1591
        public GameEventArgs(T type, Action okAction = null, Action cancelAction = null) { this.type = type; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, int? intParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.intParam = intParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, float? floatParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.floatParam = floatParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.boolParam = boolParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, object objectParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.objectParam = objectParam; this.okAction = okAction; this.cancelAction = cancelAction; }

        public GameEventArgs(T type, string str, int? intParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.intParam = intParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, float? floatParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.floatParam = floatParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.boolParam = boolParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, object objectParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.objectParam = objectParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, int? intParam, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.intParam = intParam; this.boolParam = boolParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, int? intParam, float? floatParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.intParam = intParam; this.floatParam = floatParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, int? intParam, object objectParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.intParam = intParam; this.objectParam = objectParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, float? floatParam, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.boolParam = boolParam; this.floatParam = floatParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, float? floatParam, object objectParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.objectParam = objectParam; this.floatParam = floatParam; this.okAction = okAction; this.cancelAction = cancelAction; }

        public GameEventArgs(T type, string str, int? intParam, float? floatParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.intParam = intParam; this.floatParam = floatParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, int? intParam, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.intParam = intParam; this.boolParam = boolParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, int? intParam, object objectParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.intParam = intParam; this.objectParam = objectParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, float? floatParam, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.boolParam = boolParam; this.floatParam = floatParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, float? floatParam, object objectParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.objectParam = objectParam; this.floatParam = floatParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, bool boolParam, int? intParam, float? floatParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.boolParam = boolParam; this.intParam = intParam; this.floatParam = floatParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, bool boolParam, int? intParam, object objectParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.boolParam = boolParam; this.intParam = intParam; this.objectParam = objectParam;  this.okAction = okAction; this.cancelAction = cancelAction; }

        public GameEventArgs(T type, string str, int? intParam, float? floatParam, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.intParam = intParam; this.floatParam = floatParam; this.boolParam = boolParam; this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, int? intParam, float? floatParam, object objectParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.intParam = intParam; this.floatParam = floatParam; this.objectParam = objectParam;  this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, int? intParam, object objectParam, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.intParam = intParam; this.objectParam = objectParam; this.boolParam = boolParam;  this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, string str, object objectParam, float? floatParam, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.objectParam = objectParam; this.floatParam = floatParam; this.boolParam = boolParam;  this.okAction = okAction; this.cancelAction = cancelAction; }
        public GameEventArgs(T type, object objectParam, int? intParam, float? floatParam, bool boolParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.objectParam = objectParam; this.intParam = intParam; this.floatParam = floatParam; this.boolParam = boolParam;  this.okAction = okAction; this.cancelAction = cancelAction; }

        public GameEventArgs(T type, string str, int? intParam, float? floatParam, bool boolParam, object objectParam, Action okAction = null, Action cancelAction = null) { this.type = type; this.str = str; this.intParam = intParam; this.floatParam = floatParam; this.boolParam = boolParam; this.objectParam = objectParam;  this.okAction = okAction; this.cancelAction = cancelAction; }
#pragma warning restore CS1591
    }
}