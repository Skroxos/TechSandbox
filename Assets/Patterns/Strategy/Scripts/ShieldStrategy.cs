using UnityEngine;

[CreateAssetMenu(fileName = "ShieldStrategy" , menuName = "Strategy/Shield")]
public class ShieldStrategy : SpellStrategy
{
    public GameObject prefab;
    public override void Use(Transform origin)
    {
        GameObject shiled = Instantiate(prefab, origin.position.WithY(1), Quaternion.identity, origin);
        Destroy(shiled, 5);
        Debug.Log("Used Shield");
    }
}
