using UnityEngine;
using Zenject;

namespace BallShielder
{
    [RequireComponent(typeof(HP), typeof(DamagedSpriteChanged))]
    public class Player : Debuggable
    {
        private GameManager gameManager;
        private SignalBus signalBus;

        private HP hp;
        private DamagedSpriteChanged damagedSpriteChanged;
        private Rigidbody2D rigidBody;
        private Transform shieldPivot;

        public Rigidbody2D Rigidbody => rigidBody;
        public Transform ShieldPivot => shieldPivot;
        public HP Hp  => hp;

        [Inject]
        public void Setup(GameManager gameManager, SignalBus signalBus)
        {
            this.gameManager = gameManager;
            this.signalBus = signalBus;
        }

        private void Awake()
        {
            hp = GetComponent<HP>();
            hp.SetMaxHP(gameManager.GameSettings.PlayerMaxHealth);
            damagedSpriteChanged = GetComponent<DamagedSpriteChanged>();
            shieldPivot = transform.Find("shieldPivot");
        }

        public void TakeDamage(int damage)
        {
            PrintDebugLog("Took Damage!");
            Hp.TakeDamage(damage);
            damagedSpriteChanged.TriggerDamagedSprite();
            signalBus.Fire(new PlayerDamagedSignal());
            if (Hp.IsDead)
                Die();
        }

        public void Die() => gameManager.OnPlayerDeath();
    }
}
