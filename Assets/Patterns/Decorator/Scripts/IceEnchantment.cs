namespace Patterns.Decorator.Scripts
{
    public class IceEnchantment : WeaponDecorator
    {
        private int _iceDamage;

        public IceEnchantment(IWeapon weapon, int iceDamage) : base(weapon)
        {
            _iceDamage = iceDamage;
        }

        public override int GetDamage()
        {
            return base.GetDamage() + _iceDamage;
        }
    }
}