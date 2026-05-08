using UnityEngine;

[CreateAssetMenu(fileName = "New Transition", menuName = "FSM/Transition")]
public class TransitionSo : ScriptableObject
{
    public ConditionSo condition;
    public StateSo targetState;
}