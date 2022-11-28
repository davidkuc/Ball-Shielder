using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class Shield : MonoBehaviour
    {
        private Camera camera;

        private void Awake() => camera = Camera.main;

        private void Update()
        {
            Vector3 mouseScreen = Input.mousePosition;
            Vector3 mouse = camera.ScreenToWorldPoint(mouseScreen);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);
        }
    }
}
