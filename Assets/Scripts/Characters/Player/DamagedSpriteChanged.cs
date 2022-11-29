using System.Collections;
using UnityEngine;

namespace BallShielder
{
    public class DamagedSpriteChanged : MonoBehaviour
    {
        [SerializeField] private Sprite defaultSprite;
        [SerializeField] private Sprite damagedSprite;
        [SerializeField] private float animationResetTime = 0.6f;

        private SpriteRenderer spriteRenderer;
        private Coroutine animationReset;
        private WaitForSecondsRealtime animationResetDelay;

        private void Awake()
        {
            spriteRenderer = transform.Find("sprite").GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = defaultSprite;
            animationResetDelay = new WaitForSecondsRealtime(animationResetTime);
        }

        public void TriggerDamagedSprite()
        {
            spriteRenderer.sprite = damagedSprite;
            animationReset = StartCoroutine(ResetAnimation());
        }

        private IEnumerator ResetAnimation()
        {
            if (animationReset != null)
                yield break;

            yield return animationResetDelay;
            spriteRenderer.sprite = defaultSprite;
            animationReset = null;
        }
    }
}
