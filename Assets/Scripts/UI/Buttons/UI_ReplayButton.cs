using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class UI_ReplayButton : MonoBehaviour
    {
        private GameManager gameManager;
        private LevelHandler levelHandler;
        private UI_PostGameScreen uI_PostGameScreen;

        [Inject]
        public void Setup(GameManager gameManager, UI_PostGameScreen uI_PostGameScreen, LevelHandler levelHandler)
        {
            this.gameManager = gameManager;
            this.uI_PostGameScreen = uI_PostGameScreen;
            this.levelHandler = levelHandler;
        }

        public void ReplayGame()
        {
            uI_PostGameScreen.ToggleContainer(false);
            gameManager.ToggleCursor(false);
            levelHandler.ReloadGameScene();
        }
    }
}

