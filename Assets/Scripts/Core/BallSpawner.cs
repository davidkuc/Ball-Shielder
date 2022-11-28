using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace BallShielder
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private float shootForce = 500f;
        [SerializeField] private Vector2 waitingTimeRange = new Vector2(1,10);

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
                yield return new WaitForSecondsRealtime(Random.Range(waitingTimeRange.x, waitingTimeRange.y + 1));

                var ball = ballFactory.Create();
                ball.transform.position = transform.position;
                ball.RigidBody.AddForce(Helpers.GetDirection(transform.position, shootPoint.position) * shootForce);
            }
        }
    }
}
