using UnityEngine;
using Zenject;

namespace BallShielder
{
    public class Ball : MonoBehaviour
    {
        private Player player;

        [Inject]
        private void Setup()
        {

        }
    }
}
