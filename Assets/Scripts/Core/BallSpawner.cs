using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace BallShielder
{
    public class BallSpawner : Debuggable
    {
        [SerializeField] private float shootForce = 500f;
        [SerializeField] private Vector2 waitingTimeRange = new Vector2(1, 10);

        private GameManager gameManager;
        private Ball.Pool pool;
        readonly List<Ball> balls = new List<Ball>();
        private WaitForSecondsRealtime timeToDespawn;
        private SignalBus signalBus;
        private Transform shootPoint;

        private Coroutine spawner;

        private void Awake()
        {
            shootPoint = transform.Find("shootPoint");
        }

        private void OnDisable()
        {
            StopCoroutine(spawner);
            signalBus.Unsubscribe<BallBouncedSignal>(DespawnBall);
        }

        private void OnEnable()
        {
            if (spawner != null)
                return;

            spawner = StartCoroutine(StartSpawning());
            signalBus.Subscribe<BallBouncedSignal>(DespawnBall);
        }

        [Inject]
        public void Setup(GameManager gameManager, Ball.Pool pool, SignalBus signalBus)
        {
            this.gameManager = gameManager;
            this.pool = pool;
            this.signalBus = signalBus;
            timeToDespawn = new WaitForSecondsRealtime(gameManager.GameSettings.BallDespawnTime);
        }

        private IEnumerator StartSpawning()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(Random.Range(waitingTimeRange.x, waitingTimeRange.y + 1));

                SpawnBall();
            }
        }

        private IEnumerator DespawnWithDelay()
        {
            yield return timeToDespawn;
            var ball = balls[0];
            pool.Despawn(ball);
            balls.Remove(ball);
        }

        private void SpawnBall()
        {
            var ball = pool.Spawn(transform);
            balls.Add(ball);
            ball.transform.position = transform.position;
            ball.RigidBody.AddForce(Helpers.GetDirection(transform.position, shootPoint.position) * shootForce);
        }

        private void DespawnBall()
        {
            PrintDebugLog("Despawning!");
            StartCoroutine(DespawnWithDelay());
        }
    }
}
