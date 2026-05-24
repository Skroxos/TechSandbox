using Mono.Cecil;
using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public float baseAttackPower;
    public float baseHealth;
    public float baseDefense;
    public float baseSpeed;

    public float currentAttackPower { get; set; }
    public float currentHealth { get; set; }
    public float currentDefense { get; set; }
    public float currentSpeed { get; set; }
}


public enum StatType
{
    AttackPower = 0,
    Health = 1,
    Defense = 2,
    Speed = 3,
}

public enum ModifierType
{
    Additive,
    Multiplicative
}


public class BuffDefinitionSO : ScriptableObject
{
    public StatType TargetStat;
    public ModifierType ModType;
    public float Value;
    public float Duration;

    [Header("Tick Effect (DoT)")]
    public bool IsTickEffect;
    public float TickRate;
    public float TickDamage;
}

public struct ActiveBuff
{
    public BuffDefinitionSO Definition;
    public float RemainingDuration;
    public float TimeUntilNextTick;
}