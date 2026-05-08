using System;
using UnityEngine;
using UnityEngine.AI;

public class Brain : MonoBehaviour
{
   public Transform target;
   public NavMeshAgent Agent { get; private set; }
   
   public StateSo initialState;
   private StateSo _currentState;
   


   private void Awake()
   {
         Agent = GetComponent<NavMeshAgent>();
            if (initialState != null)
            {
                _currentState = Instantiate(initialState);
                _currentState.OnEnter(this);
            }
   }

   private void Update()
   {
         if (_currentState != null)
         {
              _currentState.OnUpdate(this);
              CheckTransition();
         }
   }

   public void CheckTransition()
   {
       foreach (var transition in _currentState.transitions)
       {
           if (transition.condition.IsMet(this))
           {
               SwitchState(transition.targetState);
               break;
           }
       }
   }
   
   public void SwitchState(StateSo newState)
   {
      _currentState.OnExit(this);
      _currentState = Instantiate(newState);
      _currentState.OnEnter(this);
   }
}