using Zenject;

namespace BallShielder
{
    public class UI_Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UI_MainMenu>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}
