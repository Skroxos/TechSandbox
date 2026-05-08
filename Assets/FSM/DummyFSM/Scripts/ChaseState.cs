using System;
using UnityEngine;

namespace FSM.DummyFSM.Scripts
{
    [Serializable]
    public class ChaseState : EnemyState
    { 
        public override EnemyStateType StateType => EnemyStateType.Chase;
        [SerializeField] private float chaseRange = 5f;
        [SerializeField] private float stopChaseRange = 1f;
        public override void OnEnter(EnemyBrain brain)
        {
            Debug.Log("Entering Chase State");
            brain.Agent.SetDestination(brain.target.position);
        }

        public override void OnUpdate(EnemyBrain brain)
        {
            if (Vector3.Distance(brain.transform.position,brain.target.position) > chaseRange)
            {
                brain.SwitchState(EnemyStateType.Idle);
            }
            else if (Vector3.Distance(brain.transform.position,brain.target.position) <= stopChaseRange)
            {
                brain.SwitchState(EnemyStateType.Attack);
            }
            
            if (brain.Agent.remainingDistance > 0.1f)
            {
                brain.Agent.SetDestination(brain.target.position);
            }
        }
    
        public override void OnExit(EnemyBrain brain)
        {
            Debug.Log("Exiting Chase State");
        }
    }
}