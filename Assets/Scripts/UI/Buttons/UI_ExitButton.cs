using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class UI_ExitButton : MonoBehaviour
    {
        private GameManager gameManager;
        private UI_MainMenu uI_MainMenu;
        private UI_PostGameScreen uI_PostGameScreen;

        [Inject]
        public void Setup(GameManager gameManager, UI_MainMenu uI_MainMenu, UI_PostGameScreen uI_PostGameScreen)
        {
            this.gameManager = gameManager;
            this.uI_PostGameScreen = uI_PostGameScreen;
            this.uI_MainMenu = uI_MainMenu;
        }

        public void ExitGame()
        {
            uI_PostGameScreen.ToggleContainer(false);
            uI_MainMenu.ToggleContainer(true);
            gameManager.UnloadGameScene();
        }
    }
}
