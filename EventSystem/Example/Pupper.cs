using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pupper : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.Subscribe("OnGameStart", OnGameStart);
    }

    void OnDisable()
    {
        EventManager.Unsubscribe("OnGameStart", OnGameStart);
    }

    private void OnGameStart(Model obj)
    {
        //Bind data first
        OnGameStartModel model = (OnGameStartModel)obj;

		for (int i = 0; i < model.PlayerCount; i++)
		{
			 Debug.Log("Woof");
		}
    }

}
