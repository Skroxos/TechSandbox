namespace Patterns.Decorator.Scripts
{
    public class FireEnchantment : WeaponDecorator
    {
        private int _fireDamage;

        public FireEnchantment(IWeapon weapon, int fireDamage) : base(weapon)
        {
            _fireDamage = fireDamage;
        }

        public override int GetDamage()
        {
            return base.GetDamage() + _fireDamage;
        }
    }
}