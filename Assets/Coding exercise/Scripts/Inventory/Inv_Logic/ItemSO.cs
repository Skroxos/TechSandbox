using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable;
    public int maxStackSize;

    [SerializeField, HideInInspector] private int guid;

    public int itemID => guid;

    private void OnValidate()
    {
        if (guid == 0)
        { 
           guid = System.Guid.NewGuid().GetHashCode();
        }
    }

}
