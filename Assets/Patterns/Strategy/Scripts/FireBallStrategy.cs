using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireBallStrategy", menuName = "Strategy/FireBall")]
public class FireBallStrategy : SpellStrategy
{
    public GameObject prefab;
    public float projectilespeed = 1f;
    public override void Use(Transform origin)
    {
        var projectile = Instantiate(prefab,origin.position.WithZ(1.5f),Quaternion.identity);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.linearVelocity += origin.forward * projectilespeed;
        Destroy(projectile, 5);
        Debug.Log("Used FireBall");
    }
}
