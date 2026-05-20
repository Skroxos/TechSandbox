using System;
using System.Collections.Generic;

public static class EventBus
{
    private static readonly Dictionary<Type, object> _subscribers = new Dictionary<Type, object>();

    public static void Subscribe<T>(Action<T> callback) where T : struct, IEvent
    {
        Type eventType = typeof(T);
        if (_subscribers.TryGetValue(eventType, out object existingSubscribers))
        {
            _subscribers[eventType] = (Action<T>)existingSubscribers + callback;
        }
        else
        {
            _subscribers[eventType] = callback;
        }
    }

    public static void Unsubscribe<T>(Action<T> callback) where T : struct, IEvent
    {
        Type eventType = typeof(T);
        if (_subscribers.TryGetValue(eventType, out object existingSubscribers))
        {
            Action<T> currentCallbacks = (Action<T>)existingSubscribers - callback;

            if (currentCallbacks == null)
            {
                _subscribers.Remove(eventType);
            }
            else
            {
                _subscribers[eventType] = currentCallbacks;
            }

        }

    }

    public static void Publish<T>(T eventData) where T : struct, IEvent
    {
        Type eventType = typeof(T);
        if (_subscribers.TryGetValue(eventType, out object existingSubscribers))
        {
            Action<T> callbacks = (Action<T>)existingSubscribers;
            callbacks?.Invoke(eventData);
        }
    }
}
