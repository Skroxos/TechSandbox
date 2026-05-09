using UnityEngine;

public abstract class SpellStrategy : ScriptableObject
{
  public abstract void Use(Transform origin);
}
