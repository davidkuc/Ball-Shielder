using TMPro;
using UnityEditor;
using UnityEngine;

namespace BallShielder
{
    public class UI_PopupText : MonoBehaviour
    {
        private Vector3 defaultScale;
        private Vector3 defaultPosition;

        [SerializeField] private float x_MoveTime;
        [SerializeField] private float x_MoveDistance;
        [Space]
        [SerializeField] private float y_MoveTime;
        [SerializeField] private float y_MoveDistance;
        [SerializeField] private float y_MoveUpDelay;
        [Space]
        [SerializeField] private Vector3 targetScale;
        [SerializeField] private float scaleTime;

        private TextMeshProUGUI tmp_Text;

        private void Awake()
        {
            tmp_Text = transform.Find("text").GetComponent<TextMeshProUGUI>();

            defaultScale = transform.localScale;
            defaultPosition = transform.position;
        }

        public void TriggerPopup(string text)
        {
            this.tmp_Text.text = text;
            Animation_Test();
        }

        [ContextMenu("Animate MoveX")]
        public void Animation_MoveX() => LeanTween.moveX(gameObject, transform.position.x + x_MoveDistance, x_MoveTime);

        [ContextMenu("Animate MoveX SetEaseOutCirc")]
        public void Animation_MoveX_SetEaseOutCirc() => LeanTween.moveX(gameObject, transform.position.x + x_MoveDistance, x_MoveTime)
            .setEaseOutCirc();

        [ContextMenu("Animate MoveX SetEaseOutElastic")]
        public void Animation_MoveX_SetEaseOutElastic() => LeanTween.moveX(gameObject, transform.position.x + x_MoveDistance, x_MoveTime)
            .setEaseOutElastic();

        [ContextMenu("Animate Test")]
        public void Animation_Test()
        {
            LeanTween.moveX(gameObject, transform.position.x + x_MoveDistance, x_MoveTime).setEaseOutElastic();
            LeanTween.scale(gameObject, targetScale, scaleTime).setEaseInCubic().setLoopPingPong(1);
            LeanTween.moveY(gameObject, transform.position.y + y_MoveDistance, y_MoveTime).setEaseInElastic().setDelay(y_MoveUpDelay).setOnComplete(ResetAnim);
        }

        [ContextMenu("Reset")]
        public void ResetAnim()
        {
            LeanTween.cancel(gameObject);
            DefaultScale();
            DefaultPosition();
        }

        private void DefaultScale() => transform.localScale = defaultScale;

        private void DefaultPosition() => transform.position = defaultPosition;
    }
}
