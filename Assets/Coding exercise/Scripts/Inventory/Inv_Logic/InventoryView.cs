using UnityEngine;

public class InventoryView : MonoBehaviour
{
   [SerializeField] private InventorySlotView[] inventorySlots;

    public void UpdateInventoryUI(int index, Sprite sprite, int ammount)
    {
       if (index >= 0 && index < inventorySlots.Length)
        {
            inventorySlots[index].UpdateSlot(sprite, ammount);
        }
    }
}
