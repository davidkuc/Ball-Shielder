using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class UI_PlayButton : MonoBehaviour
    {
        private GameManager gameManager;
        private UI_MainMenu uI_MainMenu;
        private LevelHandler levelHandler;

        [Inject]
        public void Setup(GameManager gameManager, UI_MainMenu uI_MainMenu, LevelHandler levelHandler)
        {
            this.gameManager = gameManager;
            this.uI_MainMenu = uI_MainMenu;
            this.levelHandler = levelHandler;
        }

        public void StartGame()
        {
            uI_MainMenu.ToggleContainer(false);
            levelHandler.LoadGameScene();
        }
    }
}
