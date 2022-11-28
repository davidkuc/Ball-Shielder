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
            Container.BindFactory<Ball, Ball.Factory>().FromComponentInNewPrefab(ballPrefab).UnderTransformGroup("SpawnedBalls");
        }
    }
}
