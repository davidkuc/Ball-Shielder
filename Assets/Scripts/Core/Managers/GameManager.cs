using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace BallShielder
{
    public class GameManager
    {
        private GameSettings gameSettings;

        public GameSettings GameSettings  => gameSettings;

        [Inject]
        public void Setup(GameSettings gameSettings) => this.gameSettings = gameSettings;

        public void LoadGameScene()
        {
            //ZenjectSceneLoader.LoadScene(GameSettings.GameSceneName, LoadSceneMode.Additive);
            SceneManager.LoadScene(GameSettings.GameSceneName, LoadSceneMode.Additive);
        }

        public void UnloadGameScene() => SceneManager.UnloadSceneAsync(GameSettings.GameSceneName);

        public void ToggleCursor(bool active) => Cursor.visible = active;

        public void ReplayGame()
        {
            UnloadGameScene();
            LoadGameScene();
        }

        internal void OnPlayerDeath()
        {
            throw new NotImplementedException();
        }
    }
}
