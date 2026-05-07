namespace Patterns.Decorator.Scripts
{
    public abstract class WeaponDecorator : IWeapon
    {
        protected IWeapon _weapon;

        protected WeaponDecorator(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public virtual int GetDamage()
        {
            return _weapon.GetDamage();
        }
    }
}