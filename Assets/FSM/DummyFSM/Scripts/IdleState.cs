using System;
using UnityEngine;

namespace FSM.DummyFSM.Scripts
{
    [Serializable]
    public class IdleState : EnemyState
    {
        public override EnemyStateType StateType => EnemyStateType.Idle;
        [SerializeField] private float detectionRange = 3f;

        public override void OnEnter(EnemyBrain brain)
        {
            Debug.Log("Entering Idle State");
        }

        public override void OnUpdate(EnemyBrain brain)
        {
            if (Vector3.Distance(brain.transform.position,brain.target.position) <= detectionRange)
            {
                brain.SwitchState(EnemyStateType.Chase);
            }
        }

        public override void OnExit(EnemyBrain brain)
        {
            Debug.Log("Exiting Idle State");
        }
    }
}