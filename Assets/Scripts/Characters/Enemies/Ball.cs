using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class Ball : MonoBehaviour
    {
        private Player player;
        //private BallSpawner ballSpawner;
        private Rigidbody2D rigidBody;

        public Rigidbody2D RigidBody => rigidBody;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        //[Inject]
        //public void Setup(BallSpawner ballSpawner)
        //{
        //    this.ballSpawner = ballSpawner;
        //}

        public class Factory : PlaceholderFactory<Ball>
        {
        }
    }
}
