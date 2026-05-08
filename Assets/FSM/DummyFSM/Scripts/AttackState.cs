using System;
using UnityEngine;

namespace FSM.DummyFSM.Scripts
{
    [Serializable]
    public class AttackState : EnemyState
    {
        public override EnemyStateType StateType => EnemyStateType.Attack;
        [SerializeField] private float attackRange = 2f;
        public override void OnEnter(EnemyBrain brain)
        {
            Debug.Log("Entering Attack State");
        }

        public override void OnUpdate(EnemyBrain brain)
        {    
            if (Vector3.Distance(brain.transform.position,brain.target.position) > attackRange)
            {
                brain.SwitchState(EnemyStateType.Chase);
            }
            Debug.Log("Attacking Target");
        }
    
        public override void OnExit(EnemyBrain brain)
        {
            Debug.Log("Exiting Attack State");
        }
    }
}