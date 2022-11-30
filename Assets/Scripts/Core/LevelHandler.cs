using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace BallShielder
{
    public class LevelHandler : MonoBehaviour
    {
        private GameManager gameManager;
        private UI_MainMenu uI_MainMenu;
        private ZenjectSceneLoader zenjectSceneLoader;
        private AudioManager uI_AudioManager;

        public UI_MainMenu UI_MainMenu => uI_MainMenu; 

        [Inject]
        public void Setup(GameManager gameManager, UI_MainMenu uI_MainMenu, ZenjectSceneLoader zenjectSceneLoader, AudioManager uI_AudioManager)
        {
            this.gameManager = gameManager;
            this.uI_MainMenu = uI_MainMenu;
            this.zenjectSceneLoader = zenjectSceneLoader;
            this.uI_AudioManager = uI_AudioManager;
        }

        public void ReloadGameScene()
        {
            UnloadGameScene();
            LoadGameScene();
        }

        public void LoadGameScene()
        {
            zenjectSceneLoader.LoadScene(gameManager.GameSettings.GameSceneName, LoadSceneMode.Additive, (container) =>
            {
                container.BindInstance(this);
                container.BindInstance(uI_MainMenu);
                container.BindInstance(uI_AudioManager);
            });

            gameManager.ToggleCursor(false);
            gameManager.TogglePause(false);
        }

        public void UnloadGameScene() => SceneManager.UnloadSceneAsync(gameManager.GameSettings.GameSceneName);
    }
}
