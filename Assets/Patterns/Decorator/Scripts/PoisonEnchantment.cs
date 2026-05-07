namespace Patterns.Decorator.Scripts
{
    public class PoisonEnchantment : WeaponDecorator
    {
        private int _poisonDamage;

        public PoisonEnchantment(IWeapon weapon, int poisonDamage) : base(weapon)
        {
            _poisonDamage = poisonDamage;
        }

        public override int GetDamage()
        {
            return base.GetDamage() + _poisonDamage;
        }
    }
}