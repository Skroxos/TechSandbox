using UnityEngine;

namespace Patterns.Factory.Scripts.Goblin
{
    [CreateAssetMenu(fileName = "GoblinFactory", menuName = "Factory/GoblinFactory")]
    public class GoblinFactory : GeneralFactory
    { 
        public override IEnemy CreateEnemy()
        {
            return new Goblin(config);
        }
    }
}