public class AttackBoostSO : BuffEffectSO
{
    public float percentBonus;
    public override void ApplyEffect(CharacterStatsManager target)
    {
        target._stats.currentAttackPower *= (1 + percentBonus);
    }
   
}
