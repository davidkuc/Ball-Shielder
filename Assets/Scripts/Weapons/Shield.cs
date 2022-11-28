using System;
using UnityEngine;
using Zenject;
using static UnityEngine.GraphicsBuffer;

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
        public void Setup(Player player, Camera camera)
        {
            this.player = player;
            this.camera = camera;
        }

        private void Start()
        {
            center = player.ShieldPivot;
            v = (transform.position - center.position);
        }

        private void Update()
        {
            Vector3 mouseScreen = Input.mousePosition;
            Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);
        

        ///

        //var mousePos = Input.mousePosition;
        //mousePos.z = 0;
        //var objectPos = camera.WorldToScreenPoint(transform.position);

        //mousePos.x = mousePos.x - objectPos.x;
        //mousePos.y = mousePos.y - objectPos.y;

        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg/** (180 / MathF.PI)*/;
        //Debug.Log(angle);
        //transform.rotation = Quaternion.Euler(new Vector3(0,0, angle + rotationOffset));

        /////

        //var mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        ////transform.right = mousePos - transform.position;
        //transform.up = mousePos - transform.position;

        //////

        //transform.LookAt((Vector2)camera.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        //transform.LookAt((Vector2)camera.ScreenToViewportPoint(Input.mousePosition), Vector3.down);
        //transform.LookAt(Input.mousePosition, Vector3.right);

        /////

        ////Get the Screen positions of the object
        //Vector2 positionOnScreen = camera.WorldToViewportPoint(transform.position);

        ////Get the Screen position of the mouse
        //Vector2 mouseOnScreen = (Vector2)camera.ScreenToViewportPoint(Input.mousePosition);

        ////Get the angle between the points
        //float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        ////Ta Daaa
        //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        //////

        //Vector3 centerScreenPos = camera.WorldToScreenPoint(center.position);

        //Vector3 dir = camera.WorldToScreenPoint(Input.mousePosition - transform.position)/* - transform.position*/;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        /////

        //Vector3 centerScreenPos = camera.WorldToScreenPoint(center.position);
        //Vector3 dir = Input.mousePosition - centerScreenPos;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.position = center.position + q * v;
        //transform.rotation = q;
    }

        float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}
