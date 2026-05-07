namespace Patterns.Decorator.Scripts
{
    public class BasicWeapon : IWeapon
    {
        private int _damage;
        
        public BasicWeapon(int damage)
        {
            _damage = damage;
        }

        public int GetDamage()
        {
            return _damage;
        }
    }
}