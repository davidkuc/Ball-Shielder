using UnityEngine;
using Zenject;

namespace BallShielder
{
    [RequireComponent(typeof(PlayerInput), typeof(HP))]
    public class Player : MonoBehaviour
    {
        private GameManager gameManager;

        private PlayerInput input;
        private HP hp;
        private Rigidbody2D rigidBody;
        private Transform shieldPivot;

        public Rigidbody2D Rigidbody => rigidBody;
        public Transform ShieldPivot => shieldPivot;

        [Inject]
        public void Setup(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        private void Awake()
        {
            input = GetComponent<PlayerInput>();
            hp = GetComponent<HP>();
            shieldPivot = transform.Find("shieldPivot");
        }

        public void TakeDamage(int damage)
        {
            hp.TakeDamage(damage);
            if (hp.IsDead)
                Die();
        }

        public void Die() => gameManager.OnPlayerDeath();
    }
}
