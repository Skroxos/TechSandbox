using NUnit.Framework;
using UnityEngine;

public abstract class BuffEffectSO : ScriptableObject
{
    public float duration;

    public abstract void ApplyEffect(CharacterStatsManager target);
    public virtual void OnTick(float deltaTime, CharacterStatsManager target) { }
}
