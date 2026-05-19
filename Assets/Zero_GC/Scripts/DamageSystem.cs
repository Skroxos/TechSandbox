public class DamageSystem
{
    public void CalculateDamage<T>(ref T target, float damage) where T : IDamagable
    {
        target.TakeDamage(damage);
    }
}
