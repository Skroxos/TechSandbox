using UnityEngine;

public class EventTesterLogic : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 100;

    public void TakeDamage(int amount)
    {
        if (health <= 0)
        {
            return;
        }
        health -= amount;
        EventBus.Publish(new DamageTakenEvent {
            DamageTaken = amount,
            RemainingHealth = health
        });

        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        EventBus.Publish(new PlayerDieEvent());
    }
}
