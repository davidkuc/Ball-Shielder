using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject ballPrefab;

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<Shield>().FromComponentInHierarchy().AsSingle().NonLazy();
            //Container.Bind<Ball.Factory>().AsTransient().WhenInjectedInto<BallSpawner>();
            Container.BindMemoryPool<Ball, Ball.Pool>().WithInitialSize(10)
                .FromComponentInNewPrefab(ballPrefab).UnderTransformGroup("SpawnedBalls");

            //Container.Bind<ScoreValue>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}
