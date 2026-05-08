using UnityEngine;

public abstract class ConditionSo : ScriptableObject
{
    public abstract bool IsMet(Brain brain);
}