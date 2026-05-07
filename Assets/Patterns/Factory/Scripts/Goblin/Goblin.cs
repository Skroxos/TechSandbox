using UnityEngine;

namespace Patterns.Factory.Scripts.Goblin
{
    public class Goblin : IEnemy
    {
        private readonly int _health;
        private readonly int _damage;
        
        public Goblin (BaseEnemyConfig config)
        {
            _health = config.health;
            _damage = config.damage;
        }
        public void Attack()
        {
            Debug.Log("Goblin attacks!");
        }
        public void Initialize()
        {
                Debug.Log("Goblin initialized with " + _health + " health and " + _damage + " damage.");
        }
    }
}