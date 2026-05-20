using UnityEngine;

public class EventTesterAttacker : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
            if(Physics.Raycast(transform.position, -transform.right, out RaycastHit hit, 100f))
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(damageAmount);
                }
                Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
            }
        }
    }
}
