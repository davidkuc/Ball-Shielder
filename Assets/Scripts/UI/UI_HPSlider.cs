using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BallShielder
{
    public class UI_HPSlider : Debuggable
    {
        [SerializeField] private Color color_MaxHP;
        [SerializeField] private Color color_MinHP;

        private Player player;
        private GameManager gameManager;
        private SignalBus signalBus;

        private Slider hpSlider;
        private Image sliderImage;

        private void Awake()
        {
            hpSlider = GetComponent<Slider>();
            sliderImage = transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        }

        private void Start() => SetupHPSlider();

        private void OnEnable()
        {
            signalBus.Subscribe<PlayerDamagedSignal>(UpdateHPSlider);
            hpSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        }

        private void OnDisable()
        {
            signalBus.Unsubscribe<PlayerDamagedSignal>(UpdateHPSlider);
            hpSlider.onValueChanged.RemoveListener(delegate { UpdateColor(); });
        }

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

        private void UpdateHPSlider()
        {
            PrintDebugLog("Updated HP!");
            hpSlider.value = player.Hp.CurrentHP;
        }

        private void UpdateColor() => sliderImage.color = Color.Lerp(color_MinHP, color_MaxHP, hpSlider.value/ 10);
    }
}
