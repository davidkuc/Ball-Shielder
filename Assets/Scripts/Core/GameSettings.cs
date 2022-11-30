using System;
using UnityEngine;

namespace BallShielder
{
    [Serializable]
    public class GameSettings
    {
        [Header("Player")]
        [SerializeField] private int maxHealth = 10;
        [Space]
        [Header("Scene names")]
        [SerializeField] private string persistantSceneName = "PersistantScene";
        [SerializeField] private string gameSceneName = "GameScene";
        [Space]
        [Header("Layer names")]
        [SerializeField] private string playerLayerName = "Player";
        [SerializeField] private string shieldLayerName = "Shield";
        [Space]
        [Header("Ball stats")]
        [SerializeField] private int ballDamage = 1;
        [SerializeField] private int bouncePointsReward = 1;
        [SerializeField] private float ballDespawnTime = 2f;
        [Space]
        [Header("Audio")]
        [SerializeField] private AudioClip music;
        [SerializeField] private AudioClip ballBounceSFX;
        [SerializeField] private AudioClip playerHitSFX;
        [SerializeField] private AudioClip playerDeathSFX;


        public int PlayerMaxHealth => maxHealth; 

        public string PersistantSceneName  => persistantSceneName; 
        public string GameSceneName  => gameSceneName;

        public string PlayerLayerName => playerLayerName;
        public string ShieldLayerName  => shieldLayerName; 

        public int BallDamage  => ballDamage;
        public int BouncePointsReward => bouncePointsReward;
        public float BallDespawnTime => ballDespawnTime;

        public AudioClip Music => music; 
        public AudioClip BallBounceSFX => ballBounceSFX; 
        public AudioClip PlayerHitSFX => playerHitSFX;
        public AudioClip PlayerDeathSFX => playerDeathSFX; 
    }
}
