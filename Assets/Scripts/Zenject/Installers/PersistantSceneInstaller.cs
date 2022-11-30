using Zenject;

namespace BallShielder
{
    public class PersistantSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelHandler>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<UI_MainMenu>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}
