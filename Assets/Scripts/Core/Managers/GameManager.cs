using UnityEngine.SceneManagement;
using Zenject;

namespace BallShielder
{
    public class GameManager
    {
        private GameSettings gameSettings;

        [Inject]
        public void Setup(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }

        public void LoadGameScene() => SceneManager.LoadScene(gameSettings.GameSceneName, LoadSceneMode.Additive);

        public void UnloadGameScene() => SceneManager.UnloadSceneAsync(gameSettings.GameSceneName);
    }
}
