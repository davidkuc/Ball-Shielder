using System;
using UnityEngine;

namespace BallShielder
{
    [Serializable]
    public class GameSettings
    {
        [SerializeField] private string persistantSceneName = "PersistantScene";
        [SerializeField] private string gameSceneName = "GameScene";
        [Space]
        [SerializeField] private string playerLayerName = "Player";
        [SerializeField] private string shieldLayerName = "Shield";
        [Space]
        [SerializeField] private int ballDamage = 1;
        [SerializeField] private int bouncePointsReward = 1;

        public string PersistantSceneName  => persistantSceneName; 
        public string GameSceneName  => gameSceneName;

        public string PlayerLayerName => playerLayerName;
        public string ShieldLayerName  => shieldLayerName; 

        public int BallDamage  => ballDamage;
        public int BouncePointsReward => bouncePointsReward; 
    }
}
