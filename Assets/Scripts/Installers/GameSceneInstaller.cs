using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<Shield>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<Camera>().FromComponentInHierarchy().AsCached().NonLazy();
        }
    }
}
