using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class Ball : Debuggable
    {
        private Player player;
        private GameManager gameManager;
        private ScoreValue scoreValue;
        private SignalBus signalBus;
        private AudioManager audioManager;

        private Rigidbody2D rigidBody;

        private bool hasBeenBouncedOff;
        private bool shieldHasBeenHit;

        public Rigidbody2D RigidBody => rigidBody;

        private void Awake() => rigidBody = GetComponent<Rigidbody2D>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(gameManager.GameSettings.PlayerLayerName))
            {
                player.TakeDamage(gameManager.GameSettings.BallDamage);
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer(gameManager.GameSettings.ShieldLayerName) && !shieldHasBeenHit)
            {
                scoreValue.UpdateScore(gameManager.GameSettings.BouncePointsReward);
                audioManager.SFX_AudioSource.PlayOneShot(gameManager.GameSettings.BallBounceSFX);
                shieldHasBeenHit = true;
            }

            if (hasBeenBouncedOff)
                return;

            hasBeenBouncedOff = true;
            OnBallBounced();
        }

        [Inject]
        public void Setup(Player player, GameManager gameManager, ScoreValue scoreValue, SignalBus signalBus, AudioManager audioManager)
        {
            this.player = player;
            this.gameManager = gameManager;
            this.scoreValue = scoreValue;
            this.signalBus = signalBus;
            this.audioManager = audioManager;
        }

        public void OnBallBounced() => signalBus.Fire(new BallBouncedSignal() { ball = this });

        void Reset(Transform resetPosition)
        {
            transform.position = resetPosition.position;
            hasBeenBouncedOff = false;
            shieldHasBeenHit = false;
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
