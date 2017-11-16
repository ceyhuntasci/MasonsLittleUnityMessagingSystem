﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;

public class EventManager : MonoBehaviour
{
    private static Dictionary<string, List<Action<Model>>> eventDictionary = new Dictionary<string, List<Action<Model>>>();

    public static void Subscribe(string channel, Action<Model> action)
    {
        List<Action<Model>> actionList = null;

        if (eventDictionary.TryGetValue(channel, out actionList))
        {
            actionList.Add(action);
        }
        else
        {
            actionList = new List<Action<Model>>();
            actionList.Add(action);
            eventDictionary.Add(channel, actionList);
        }
    }

    public static void Unsubscribe(string channel, Action<Model> action)
    {
        List<Action<Model>> actionList = null;

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

    public static void TriggerEvent(string eventName, Model model)
    {
        List<Action<Model>> thisEventList = null;

        if (eventDictionary.TryGetValue(eventName, out thisEventList))
        {
            for (int i = 0; i < thisEventList.Count; i++)
            {
                try
                {
                    thisEventList[i].Invoke(model);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
        }
    }
}