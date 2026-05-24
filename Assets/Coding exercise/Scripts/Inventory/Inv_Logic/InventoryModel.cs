
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
  private ItemSlot[] itemSlots;
   private Dictionary<int, int> itemDictionary = new Dictionary<int, int>();
    public event Action<int,Sprite,int> OnInventoryChanged;

    public InventoryModel(int size)
    {
        itemSlots = new ItemSlot[size];
        itemDictionary = new Dictionary<int, int>();
        for (int i = 0; i < size; i++)
        {
            itemSlots[i] = new ItemSlot { slotID = i };
        }
    }

        public bool AddItem(ItemSO item, int quantity)
        {
        if (item.isStackable)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (!itemSlots[i].IsEmpty && itemSlots[i].item.itemID == item.itemID && !itemSlots[i].IsFull)
                {
                    int availableSpace = item.maxStackSize - itemSlots[i].quantity;
                    int quantityToAdd = Mathf.Min(availableSpace, quantity);
                    itemSlots[i].quantity += quantityToAdd;
                    quantity -= quantityToAdd;
                    OnInventoryChanged?.Invoke(i, item.itemIcon, itemSlots[i].quantity);
                        if (itemDictionary.ContainsKey(item.itemID))
                        {
                            itemDictionary[item.itemID] += quantityToAdd;
                        }
                        else
                        {
                            itemDictionary.Add(item.itemID, quantityToAdd);
                        }
                        if (quantity <= 0)
                        {
                        return true;
                        }
                }
            }
        }
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].IsEmpty)
            {
                int quantityToAdd = item.isStackable ? Mathf.Min(item.maxStackSize, quantity) : 1;
                itemSlots[i].item = item;
                itemSlots[i].quantity = quantityToAdd;
                quantity -= quantityToAdd;
                OnInventoryChanged?.Invoke(i, item.itemIcon, itemSlots[i].quantity);
                if (itemDictionary.ContainsKey(item.itemID))
                {
                    itemDictionary[item.itemID] += quantityToAdd;
                }
                else
                {
                    itemDictionary.Add(item.itemID, quantityToAdd);
                 }
                 if (quantity <= 0)
                    {
                        return true;
                }
            }
        }
            return false;
    }



    public bool RemoveItem(ItemSO item, int quantity)
    {
        itemDictionary[item.itemID] -= quantity;
        if (itemDictionary[item.itemID] <= 0)
        {
            itemDictionary.Remove(item.itemID);
        }
        for (int i = itemSlots.Length - 1; i >= 0; i--)
        {
            if (!itemSlots[i].IsEmpty && itemSlots[i].item.itemID == item.itemID)
            {
                int quantityToRemove = Mathf.Min(itemSlots[i].quantity, quantity);

                itemSlots[i].quantity -= quantityToRemove;
                quantity -= quantityToRemove;

                if (itemSlots[i].quantity <= 0)
                {
                    itemSlots[i].item = null;
                    OnInventoryChanged?.Invoke(i, null, 0);
                }
                else
                {
                    OnInventoryChanged?.Invoke(i, item.itemIcon, itemSlots[i].quantity);
                }

                if (quantity <= 0)
                {
                    return true;
                }
            }
        }

        return false;
    }


    public bool HasItemForCrafting(int itemID, int quantity)
    {
        return itemDictionary.ContainsKey(itemID) && itemDictionary[itemID] >= quantity;
    }
}
