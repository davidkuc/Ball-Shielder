using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace BallShielder
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private float shootForce;
        [SerializeField] private Vector2 waitingTimeRange;

        private GameManager gameManager;
        private Ball.Factory ballFactory;
        private Transform shootPoint;

        private Coroutine spawner;

        private void Awake() => shootPoint = transform.Find("shootPoint");

        private void OnDisable() => StopCoroutine(spawner);

        private void OnEnable()
        {
            if (spawner != null)
                return;

            spawner = StartCoroutine(StartSpawning());
        }

        [Inject]
        public void Setup(GameManager gameManager, Ball.Factory ballFactory)
        {
            this.gameManager = gameManager;
            this.ballFactory = ballFactory;
        }

        private IEnumerator StartSpawning()
        {
            while (true)
            {
                // spawn prefab
                var ball = ballFactory.Create();
                ball.transform.position = transform.position;
                // add force
                ball.RigidBody.AddForce(Helpers.GetDirection(transform.position, shootPoint.position) * shootForce);

                // wait until next spawn
                yield return new WaitForSecondsRealtime(Random.Range(waitingTimeRange.x, waitingTimeRange.y + 1));
            }
        }
    }
}
