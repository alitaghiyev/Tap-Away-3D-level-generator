using System;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoSingleton<EventManager>
{
    #region  GENERIC EVENT CLASSES
    [Serializable] public class GameEvent : UnityEvent { }
    [Serializable] public class GameEvent<T0> : UnityEvent<T0> { }
    [Serializable] public class GameEvent<T0, T1> : UnityEvent<T0, T1> { }
    [Serializable] public class GameEvent<T0, T1, T3> : UnityEvent<T0, T1, T3> { }
    #endregion
    public GameEvent CorrectClick;
    public GameEvent WrongClick;

    public GameEvent CompleteLevelGeneration;

}
