using UnityEngine;

namespace Patterns.Factory.Scripts.Skeleton
{
    [CreateAssetMenu(fileName = "SkeletonFactory", menuName = "Factory/SkeletonFactory")]
    public class SkeletonFactory : GeneralFactory
    {
        public override IEnemy CreateEnemy()
        {
            return new Skeleton(config);
        }
    }
}