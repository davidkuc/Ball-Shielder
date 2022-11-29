using UnityEngine;
using Zenject;

namespace BallShielder
{
    [RequireComponent(typeof(HP), typeof(DamagedSpriteChanged))]
    public class Player : Debuggable
    {
        private GameManager gameManager;
        private UI_PostGameScreen uI_PostGameScreen;
        private SignalBus signalBus;

        private HP hp;
        private DamagedSpriteChanged damagedSpriteChanged;
        private Rigidbody2D rigidBody;
        private Transform shieldPivot;

        public Rigidbody2D Rigidbody => rigidBody;
        public Transform ShieldPivot => shieldPivot;
        public HP Hp  => hp;

        [Inject]
        public void Setup(GameManager gameManager, SignalBus signalBus, UI_PostGameScreen uI_PostGameScreen)
        {
            this.gameManager = gameManager;
            this.signalBus = signalBus;
            this.uI_PostGameScreen = uI_PostGameScreen;
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

        public void Die()
        {
            uI_PostGameScreen.ToggleContainer(true);
            gameManager.ToggleCursor(true);
        }
    }
}
