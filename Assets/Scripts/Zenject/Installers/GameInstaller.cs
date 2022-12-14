using UnityEngine;
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
            Container.DeclareSignal<MilestoneReachedSignal>();

            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        }
    }
}
