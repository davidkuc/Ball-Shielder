using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class UI_ReplayButton : MonoBehaviour
    {
        private GameManager gameManager;
        private UI_PostGameScreen uI_PostGameScreen;

        [Inject]
        public void Setup(GameManager gameManager, UI_PostGameScreen uI_PostGameScreen)
        {
            this.gameManager = gameManager;
            this.uI_PostGameScreen = uI_PostGameScreen; 
        }

        public void ReplayGame()
        {
            uI_PostGameScreen.ToggleContainer(false);
            gameManager.ReplayGame();
            gameManager.ToggleCursor(false);
        }
    }
}

