using System.Collections.Generic;
using UnityEngine;

public abstract class StateSo : ScriptableObject
{
    public List<TransitionSo> transitions;
    public abstract void OnEnter(Brain brain);
    public abstract void OnExit(Brain brain);
    public abstract void OnUpdate(Brain brain);
}