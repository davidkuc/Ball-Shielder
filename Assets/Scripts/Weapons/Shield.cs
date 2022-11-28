using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float rotationOffset = 5f;

        private Player player;
        private Camera camera;
        private Transform center;
        private Vector3 v;

        [Inject]
        public void Setup(Player player)
        {
            this.player = player;
        }

        private void Awake()
        {
            camera = Camera.main;
        }
        private void Update()
        {
            Vector3 mouseScreen = Input.mousePosition;
            Vector3 mouse = camera.ScreenToWorldPoint(mouseScreen);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);
        }

    }
}
