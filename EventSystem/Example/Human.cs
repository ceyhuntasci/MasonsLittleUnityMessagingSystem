using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
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

        Debug.LogFormat("Game Mode is {0} with {1} players", model.GameMode, model.PlayerCount);
    }

}
