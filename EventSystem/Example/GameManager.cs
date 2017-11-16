using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        EventManager.TriggerEvent("OnGameStart", new OnGameStartModel("Multiplayer", 2));
    }
}
