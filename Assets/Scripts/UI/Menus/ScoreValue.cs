using TMPro;
using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class ScoreValue : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;
        private int score;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
            scoreText.text = "0";
        }

        public void UpdateScore(int points)
        {
            score += points;
            scoreText.text = score.ToString();
        }
    }
}
