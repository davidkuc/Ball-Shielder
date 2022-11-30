using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace BallShielder
{
    public class GameManager
    {
        private GameSettings gameSettings;

        public GameSettings GameSettings => gameSettings;

        [Inject]
        public void Setup(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }

        public void UnloadGameScene() => SceneManager.UnloadSceneAsync(GameSettings.GameSceneName);

        public void ToggleCursor(bool active) => Cursor.visible = active;

        public void TogglePause(bool gamePaused)
        {
            if (gamePaused)
                Time.timeScale = 0;

            else
                Time.timeScale = 1;
        }
    }
}
