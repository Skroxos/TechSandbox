using Patterns.Factory.Scripts.Skeleton;
using UnityEngine;

namespace Patterns.Factory.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GeneralFactory factory;
        private void Start()
        {
            IEnemy enemy = factory.CreateEnemy();
            enemy.Initialize();
            enemy.Attack();
        }
    }
}