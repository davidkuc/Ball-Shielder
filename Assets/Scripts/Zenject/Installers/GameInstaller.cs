using Zenject;

namespace BallShielder
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<BallBouncedSignal>();
            Container.DeclareSignal<PlayerDamagedSignal>();

            Container.Bind<UI_MainMenu>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<UI_PostGameScreen>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        }
    }
}
