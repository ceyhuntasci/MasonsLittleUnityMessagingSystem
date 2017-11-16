using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameStartModel : Model
{
    public string GameMode;
    public int PlayerCount;

    public OnGameStartModel(string gameMode, int playerCount)
    {
        GameMode = gameMode;
        PlayerCount = playerCount;
    }
}
