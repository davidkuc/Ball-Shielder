using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace BallShielder
{
    public class LevelHandler : MonoBehaviour
    {
        private UI_MainMenu uI_MainMenu;
        private ZenjectSceneLoader zenjectSceneLoader;
        private GameManager gameManager;

        public UI_MainMenu UI_MainMenu => uI_MainMenu; 

        [Inject]
        public void Setup(GameManager gameManager, UI_MainMenu uI_MainMenu, ZenjectSceneLoader zenjectSceneLoader)
        {
            this.gameManager = gameManager;
            this.uI_MainMenu = uI_MainMenu;
            this.zenjectSceneLoader = zenjectSceneLoader;
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
            });

            gameManager.ToggleCursor(false);
        }

        public void UnloadGameScene() => SceneManager.UnloadSceneAsync(gameManager.GameSettings.GameSceneName);
    }
}
