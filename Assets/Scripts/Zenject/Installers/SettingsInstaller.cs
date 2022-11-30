using UnityEngine;
using Zenject;

namespace BallShielder
{
    [CreateAssetMenu(fileName = "SettingsInstaller_SO", menuName = "Scriptable Object/SettingsInstaller")]
    public class SettingsInstaller : ScriptableObjectInstaller
    {
       [SerializeField] private GameSettings gameSettings;

        public override void InstallBindings() => Container.BindInstance(gameSettings).AsSingle().NonLazy();
    }
}
