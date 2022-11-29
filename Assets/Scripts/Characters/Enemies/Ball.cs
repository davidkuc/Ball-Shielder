using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class Ball : MonoBehaviour
    {
        private Player player;
        private GameManager gameManager;
        private ScoreValue scoreValue;
        private SignalBus signalBus;
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

            OnBallBounced();
        }

        [Inject]
        public void Setup(Player player, GameManager gameManager, ScoreValue scoreValue, SignalBus signalBus)
        {
            this.player = player;
            this.gameManager = gameManager;
            this.scoreValue = scoreValue;
            this.signalBus = signalBus;
        }

        public void OnBallBounced() => signalBus.Fire(new BallBouncedSignal() { ball = this });

        void Reset(Transform resetPosition)
        {
            transform.position = resetPosition.position;
            hasBeenBouncedOff = false;
        }

        public class Pool : MonoMemoryPool<Transform, Ball>
        {
            protected override void Reinitialize(Transform resetPosition, Ball item)
            {
                base.Reinitialize(resetPosition, item);
                item.Reset(resetPosition);
            }
        }
    }
}
