using UnityEngine;

[CreateAssetMenu(fileName = "HealStrategy", menuName = "Strategy/Heal")]
public class HealStrategy : SpellStrategy
{
    public override void Use(Transform origin)
    {
        Debug.Log("Used Heal");
    }
}
