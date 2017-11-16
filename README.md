## Mason's Little Unity Messaging System
This little framework lets scripts communicate between themselves easily. Create your game events and make every script handle their actions.


## Usage

* Create Data Models:

 ```csharp
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
 ```

* Subscribe & Unsubscribe to Message Channels

 ```csharp
    void OnEnable()
    {
        EventManager.Subscribe("OnGameStart", OnGameStart);
    }
    void OnDisable()
    {
        EventManager.Unsubscribe("OnGameStart", OnGameStart);
    }
    void OnGameStart(Model obj)
    {
        //Bind data first
        OnGameStartModel model = (OnGameStartModel)obj;

        Debug.LogFormat("Game Mode is {0} with {1} players", model.GameMode, model.PlayerCount);
    }
 ```

* Trigger Events

 ```csharp
    EventManager.TriggerEvent("OnGameStart", new OnGameStartModel("Multiplayer", 2));
 ```


