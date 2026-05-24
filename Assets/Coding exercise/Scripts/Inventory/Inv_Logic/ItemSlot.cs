public class ItemSlot
{
    public ItemSO item;
    public int quantity;
    public int slotID;

    public bool IsEmpty => item == null;
    public bool IsFull => item != null && quantity >= item.maxStackSize;
}
