using UnityEngine;

public class DamageOverTimeSO : BuffEffectSO
{
    public float damagePerSecond;
    public override void ApplyEffect(CharacterStatsManager target)
    {
       
    }
    public override void OnTick(float deltaTime, CharacterStatsManager target)
    {
        float damageThisTick = damagePerSecond * deltaTime;
        Debug.Log($"Applying {damageThisTick} damage to target.");
    }
}
