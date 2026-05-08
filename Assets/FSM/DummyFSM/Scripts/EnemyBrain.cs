using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FSM.DummyFSM.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyBrain : MonoBehaviour
    {
        [Header("References")]
        public Transform target;
        public NavMeshAgent Agent { get; private set; }
    
        [Header("State Machine")]
        [SerializeReference, SubclassSelector, SerializeField]
        private List<EnemyState> _availableStates = new List<EnemyState>();
        private EnemyState _currentState;
        public EnemyStateType CurrentStateType { get; private set; }
        private Dictionary<EnemyStateType, EnemyState> _stateDictionary;


        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            InitializeStates();
        }

        private void Start()
        {
            SwitchState(EnemyStateType.Idle);
        }

        private void Update()
        {
            _currentState?.OnUpdate(this);
        }

        private void InitializeStates()
        {
            _stateDictionary = new Dictionary<EnemyStateType, EnemyState>();
            foreach (var state in _availableStates)
            {
                _stateDictionary[state.StateType] = state;
            }
        }

        public void SwitchState(EnemyStateType newStateType)
        {
            if (_stateDictionary.TryGetValue(newStateType, out var state))
            {
                _currentState?.OnExit(this);
                _currentState = state;
                _currentState.OnEnter(this);
                
                CurrentStateType = newStateType;
            }
        }
    }
}