using System;
using UnityEngine;

namespace BallShielder
{
    [Serializable]
    public class GameSettings
    {
        [SerializeField] private string persistantSceneName = "PersistantScene";
        [SerializeField] private string gameSceneName = "GameScene";

        public string PersistantSceneName  => persistantSceneName; 
        public string GameSceneName  => gameSceneName;
    }
}
