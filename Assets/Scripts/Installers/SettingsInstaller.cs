using UnityEngine;
using Zenject;

namespace BallShielder
{
    [CreateAssetMenu(fileName = "SettingsInstaller_SO", menuName = "Scriptable Object/SettingsInstaller")]
    public class SettingsInstaller : ScriptableObjectInstaller
    {
        public GameSettings gameSettings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameSettings>().AsSingle();
        }
    }
}
