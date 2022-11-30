using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject ballPrefab;

        public override void InstallBindings()
        {
            Container.Bind<UI_PostGameScreen>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.Bind<Player>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<Shield>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindMemoryPool<Ball, Ball.Pool>().WithInitialSize(10)
              .FromComponentInNewPrefab(ballPrefab).UnderTransformGroup("SpawnedBalls");
        }
    }
}
