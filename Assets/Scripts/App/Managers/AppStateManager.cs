using SnowGame.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowGame
{
    public class AppStateManager : IService, IAppStateManager
    {
        private IUIManager _uiManager;
        public Enumerators.AppState AppState { get; set; } = Enumerators.AppState.Undefined;

        public void Init()
        {
            _uiManager = GameClient.Get<IUIManager>();
        }

        public void Update()
        {
        }

        public void ChangeAppState(Enumerators.AppState stateTo)
        {
            if (AppState == stateTo)
                return;

            AppState = stateTo;

            switch (stateTo)
            {
                case Enumerators.AppState.MainMenu:
                    //_uiManager.SetPage<GamePage>();
                    //GameClient.Get<IGameplayManager>().StartGameplay();
                    break;
                case Enumerators.AppState.Game:
                    //GameClient.Get<IGameplayManager>().StopGameplay();
                    //_uiManager.SetPage<MainPage>();
                    break;
            }
        }

        public void PauseGame(bool enablePause)
        {
            if (enablePause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public void Dispose()
        {
        }
    }
}