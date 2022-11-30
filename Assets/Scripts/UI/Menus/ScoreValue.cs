using TMPro;
using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class ScoreValue : MonoBehaviour
    {
        private UI_PopupTextManager uI_PopupTextManager;
        private TextMeshProUGUI scoreText;
        private int score;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
            scoreText.text = "0";
        }

        [Inject]
        public void Setup(UI_PopupTextManager uI_PopupTextManager) => this.uI_PopupTextManager = uI_PopupTextManager;

        public void UpdateScore(int points)
        {
            score += points;
            scoreText.text = score.ToString();
            if (score % 10 == 0)
                uI_PopupTextManager.TriggerPopup();
        }
    }
}
