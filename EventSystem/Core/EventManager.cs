using UnityEngine;
using System.Collections.Generic;
using System;

public static class EventManager
{
    private static Dictionary<string, List<Action<EventModel>>> eventDictionary = new Dictionary<string, List<Action<EventModel>>>();

    public static void Subscribe(string channel, Action<EventModel> action)
    {
        List<Action<EventModel>> actionList = null;

        if (eventDictionary.TryGetValue(channel, out actionList))
        {
            if (!actionList.Contains(action))
            {
                actionList.Add(action);
            }
        }
        else
        {
            actionList = new List<Action<EventModel>>();
            actionList.Add(action);
            eventDictionary.Add(channel, actionList);
        }
    }

    public static void Subscribe(string channel, Action<EventModel> action, int eventQueue)
    {
        List<Action<EventModel>> actionList = null;

        if (eventDictionary.TryGetValue(channel, out actionList))
        {
            if (!actionList.Contains(action))
            {
                actionList.Insert(eventQueue, action);
            }
        }
        else
        {
            actionList = new List<Action<EventModel>>();
            actionList.Add(action);
            eventDictionary.Add(channel, actionList);
        }
    }

    public static void Unsubscribe(string channel, Action<EventModel> action)
    {
        List<Action<EventModel>> actionList = null;

        if (eventDictionary.TryGetValue(channel, out actionList))
        {
            if (actionList.Contains(action))
            {
                actionList.Remove(action);
            }
        }
        else
        {
            Debug.Log("Action is not subscribed");
        }
    }

    public static void TriggerEvent(string eventName, EventModel EventModel)
    {
        List<Action<EventModel>> thisEventList = null;

        if (eventDictionary.TryGetValue(eventName, out thisEventList))
        {
            List<Action<EventModel>> temp = new List<Action<EventModel>>();
            temp.AddRange(thisEventList);
            for (int i = 0; i < temp.Count; i++)
            {
                try
                {
                    temp[i].Invoke(EventModel);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                    Debug.Log(e.Source);
                    Debug.LogError(e.InnerException);
                    Debug.LogError(e.StackTrace);
                }
            }
        }
    }
}