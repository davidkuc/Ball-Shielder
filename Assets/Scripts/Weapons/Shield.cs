using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class Shield : MonoBehaviour
    {
        private Player player;
        private Transform center;
        private Vector3 v;

        [Inject]
        public void Setup(Player player)
        {
            this.player = player;
        }

        private void Start()
        {
            center = player.ShieldPivot;
            v = (transform.position - center.position);
        }

        void Update()
        {
            // Optimize camera.main
            Vector3 centerScreenPos = Camera.main.WorldToScreenPoint(center.position);
            Vector3 dir = Input.mousePosition - centerScreenPos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = center.position + q * v;
            transform.rotation = q;
        }


        //public void RotateAroundPlayer()
        // {
        //     // where is our center on screen?
        //     Vector3 center = player.transform.position;

        //     // angle to previous finger
        //     float anglePrevious = Mathf.Atan2(center.x - lastPosition.x, lastPosition.y - center.y);

        //     Vector3 currPosition = Input.mousePosition;

        //     // angle to current finger
        //     float angleNow = Mathf.Atan2(center.x - currPosition.x, currPosition.y - center.y);

        //     lastPosition = currPosition;

        //     // how different are those angles?
        //     float angleDelta = angleNow - anglePrevious;

        //     // rotate by that much
        //     transform.Rotate(new Vector3(0, 0, angleDelta * Mathf.Rad2Deg));
        // }
    }
}
