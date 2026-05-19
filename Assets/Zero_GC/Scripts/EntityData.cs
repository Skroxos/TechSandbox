using UnityEngine;

public struct EntityData : IDamagable
{
    public float Health;
    

    public EntityData(float health)
    {
        Health = health;
    }

    public void TakeDamage(float damage)
    {
        if (Health <= 0.0f) return;
        Health -= damage;
        Debug.Log(Health);
        if (Health == 0.0f)
        {
            Die();
        }
    }


    private void Die()
    {
        Debug.Log($"Died {this}");
    }
}
