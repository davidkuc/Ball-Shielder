using System.ComponentModel;
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
            PrintDebugLog($"Is PostGameScreen null? ==> {this.uI_PostGameScreen == null}");
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
            if (Hp.IsDead)
                return;

            PrintDebugLog("Took Damage!");
            Hp.TakeDamage(damage);
            damagedSpriteChanged.TriggerDamagedSprite();
            signalBus.Fire(new PlayerDamagedSignal());
            if (Hp.IsDead)
                Die();
        }

        [ContextMenu("Die")]
        public void Die()
        {
            PrintDebugLog($"Is PostGameScreen null? (After death) ==> {this.uI_PostGameScreen == null}");
            PrintDebugLog($"(After death) Container null? ==> {uI_PostGameScreen.Container == null} \r\n" +
    $" Canvas null? ==> {uI_PostGameScreen.Canvas == null}");
            uI_PostGameScreen.ToggleContainer(true);
            gameManager.ToggleCursor(true);
        }
    }
}
