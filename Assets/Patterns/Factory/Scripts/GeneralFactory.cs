using UnityEngine;

namespace Patterns.Factory.Scripts
{
    public abstract class GeneralFactory : ScriptableObject
    {
        [SerializeField] protected BaseEnemyConfig config;
        public abstract IEnemy CreateEnemy();
    }
}