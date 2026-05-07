using UnityEngine;

namespace Patterns.Factory.Scripts
{
    [CreateAssetMenu(fileName = "BaseEnemyConfig", menuName = "Factory/BaseEnemyConfig")]
    public class BaseEnemyConfig : ScriptableObject
    {
        public int health;
        public int damage;
    }
}