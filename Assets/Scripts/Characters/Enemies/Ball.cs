using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class Ball : MonoBehaviour
    {
        private Player player;
        private GameManager gameManager;
        private ScoreValue scoreValue;
        private Rigidbody2D rigidBody;

        private bool hasBeenBouncedOff;

        public Rigidbody2D RigidBody => rigidBody;

        private void Awake() => rigidBody = GetComponent<Rigidbody2D>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (hasBeenBouncedOff)
                return;

            if (collision.gameObject.layer == LayerMask.NameToLayer(gameManager.GameSettings.PlayerLayerName))
            {
                player.TakeDamage(gameManager.GameSettings.BallDamage);
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer(gameManager.GameSettings.ShieldLayerName))
            {
                hasBeenBouncedOff = true;
                scoreValue.UpdateScore(gameManager.GameSettings.BouncePointsReward);
            }
        }

        [Inject]
        public void Setup(GameManager gameManager, ScoreValue scoreValue)
        {
            this.gameManager = gameManager;
            this.scoreValue = scoreValue;
        }

        public class Factory : PlaceholderFactory<Ball>
        {
        }
    }
}
