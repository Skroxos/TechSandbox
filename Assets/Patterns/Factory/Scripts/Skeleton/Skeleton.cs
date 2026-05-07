using UnityEngine;

namespace Patterns.Factory.Scripts.Skeleton
{
    public class Skeleton : IEnemy
    {
        public int Health { get; private set; }
        public int Damage  { get; private set; }
        
        public Skeleton (BaseEnemyConfig config)
        {
            Health = config.health;
            Damage = config.damage;
        }

        public void ThrowBone()
        {
            Debug.Log("Skeleton throws a bone!");
        }
        public void Attack()
        {
            Debug.Log("Skeleton attacks!");
        }

        public void Initialize()
        {
                Debug.Log("Skeleton initialized with " + Health + " health and " + Damage + " damage.");
                ThrowBone();
        }
    }
}