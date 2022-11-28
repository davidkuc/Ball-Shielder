using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class UI_PlayButton : MonoBehaviour
    {
        private GameManager gameManager;
        private UI_MainMenu uI_MainMenu;

        [Inject]
        public void Setup(GameManager gameManager, UI_MainMenu uI_MainMenu)
        {
            this.gameManager = gameManager;
            this.uI_MainMenu = uI_MainMenu;
        }

        public void StartGame()
        {
            uI_MainMenu.ToggleContainer(false);
            gameManager.LoadGameScene();
        }
    }
}
