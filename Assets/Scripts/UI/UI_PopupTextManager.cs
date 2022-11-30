using UnityEditor;
using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class UI_PopupTextManager : MonoBehaviour
    {
        private UI_PopupText uI_TextPopup;
        private SignalBus signalBus;

        private string[] texts = new string[]
        {
            "Keep going!",
            "You're doing great!",
            "Woah, you're on fire!",
            "Yoyo slow down!",
            "Bazinga",
            "You still playing this? XDD",
            "Hope your enjoying!",
            "Kick dem ballz!",
            "You like ballz?",
            "Bouncy bouncy hehe",
            "Merry christmas!",
            "Happy thanksgiving!",
            "Remember to take a break!",
            "Eat fruits and vegetables!",
            "Brush your teeth!",
            "You're awesome!",
            "Nice day, isn't it?"
        };

        private void OnEnable() => signalBus.Subscribe<MilestoneReachedSignal>(TriggerPopup);

        private void OnDisable() => signalBus.Unsubscribe<MilestoneReachedSignal>(TriggerPopup);

        [Inject]
        public void Setup(UI_PopupText uI_TextPopup, SignalBus signalBus)
        {
            this.uI_TextPopup = uI_TextPopup;
            this.signalBus = signalBus;
        }

        public void TriggerPopup() => uI_TextPopup.TriggerPopup(texts[Random.Range(0, texts.Length - 1)].ToUpper());
    }
}
