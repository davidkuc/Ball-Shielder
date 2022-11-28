using System;
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

        public GameManager()
        {
            Cursor.visible = false;
        }

        public void LoadGameScene() => SceneManager.LoadScene(GameSettings.GameSceneName, LoadSceneMode.Additive);

        public void UnloadGameScene() => SceneManager.UnloadSceneAsync(GameSettings.GameSceneName);

        public void OnPlayerDeath()
        {
            
        }
    }
}
