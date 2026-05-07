using UnityEngine;

namespace Patterns.Decorator.Scripts
{
    public class TestDecorator : MonoBehaviour
    {
        private void Start()
        {
            IWeapon basicWeapon = new BasicWeapon(10);
            Debug.Log("Basic Weapon Damage: " + basicWeapon.GetDamage());

            IWeapon iceWeapon = new IceEnchantment(basicWeapon, 5);
            Debug.Log("Ice Enchanted Weapon Damage: " + iceWeapon.GetDamage());

            IWeapon poisonWeapon = new PoisonEnchantment(iceWeapon, 3);
            Debug.Log("Poison Enchanted Weapon Damage: " + poisonWeapon.GetDamage());
        }
        
    }
}