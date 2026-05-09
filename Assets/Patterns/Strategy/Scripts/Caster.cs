using UnityEngine;

public class Caster : MonoBehaviour
{
    [SerializeField] private SpellStrategy[] spellStrategies;

    private void OnEnable()
    {
        UIStuff.OnButtonPressed += UIStuff_OnButtonPressed;
    }
    private void OnDisable()
    {
        UIStuff.OnButtonPressed -= UIStuff_OnButtonPressed;
    }

    private void UIStuff_OnButtonPressed(int obj)
    {
        spellStrategies[obj].Use(transform);
    }

}
