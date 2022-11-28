namespace BallShielder
{
    public class HP : Debuggable
    {
        private int maxHP;
        private int currentHP;

        public bool IsDead => CurrentHP <= 0;

        public int CurrentHP => currentHP;

        public void SetMaxHP(int maxHP)
        {
            this.maxHP = maxHP;
            currentHP = maxHP;
        }

        public void TakeDamage(int damagePerHit) => currentHP -= damagePerHit;

        public void Die()
        {
            PrintDebugLog("Destroying");
            Destroy(gameObject);
        }

        public void ResetHP() => currentHP = maxHP;
    }
}