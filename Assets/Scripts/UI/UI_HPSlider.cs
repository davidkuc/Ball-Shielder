using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BallShielder
{
    public class UI_HPSlider : Debuggable
    {
        private Player player;
        private GameManager gameManager;
        private SignalBus signalBus;

        private Slider hpSlider;

        private void Awake() => hpSlider = GetComponent<Slider>();

        private void Start() => SetupHPSlider();

        private void OnEnable() => signalBus.Subscribe<PlayerDamagedSignal>(UpdateHPSlider);

        private void OnDisable() => signalBus.Unsubscribe<PlayerDamagedSignal>(UpdateHPSlider);

        [Inject]
        public void Setup(GameManager gameManager, Player player, SignalBus signalBus)
        {
            this.gameManager = gameManager;
            this.player = player;
            this.signalBus = signalBus;
        }

        private void SetupHPSlider()
        {
            hpSlider.wholeNumbers = true;
            hpSlider.minValue = 0;
            hpSlider.maxValue = gameManager.GameSettings.PlayerMaxHealth;
            UpdateHPSlider();
        }

        public void UpdateHPSlider()
        {
            PrintDebugLog("Updated HP!");
            hpSlider.value = player.Hp.CurrentHP;
        }
    }
}
