
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
            if (item == null || quantity <= 0) return false;
            int remainingQuantity = quantity;
            if (item.isStackable)
            {
                remainingQuantity = FillExistingStacks(item, remainingQuantity);
            }
            if (remainingQuantity > 0)
            {
                remainingQuantity = FillEmptySlots(item, remainingQuantity);
            }
            return remainingQuantity == 0;

        }


        public bool RemoveItem(ItemSO item, int quantity)
        {
            if (!HasItem(item.itemID))
            {
                return false;
            }
            int remainingQuantity = RemoveQuantity(item, quantity);
            if (remainingQuantity > 0)
            {
                RemoveFromSlots(item, remainingQuantity);
            }
            return true;
        }


        public bool HasItemForCrafting(int itemID, int quantity)
        {
            return itemDictionary.ContainsKey(itemID) && itemDictionary[itemID] >= quantity;
        }






    
        private int RemoveQuantity(ItemSO item, int quantity)
        {
        return Mathf.Min(quantity, itemDictionary[item.itemID]);
        }

        private bool HasItem(int itemID)
        {
            return itemDictionary.ContainsKey(itemID) && itemDictionary[itemID] > 0;
        }

        private void RemoveFromSlots(ItemSO item, int quantity)
        {
            int remainingQuantity = quantity;
            for (int i = itemSlots.Length - 1; i >= 0 && remainingQuantity > 0; i--)
            {
                ItemSlot slot = itemSlots[i];
                if (slot.IsEmpty || slot.item.itemID != item.itemID) continue;
                int quantityToRemove = Mathf.Min(slot.quantity, remainingQuantity);
                slot.quantity -= quantityToRemove;
                remainingQuantity -= quantityToRemove;
                RemoveFromDictionary(item, quantityToRemove);
                OnInventoryChanged?.Invoke(i, item.itemIcon, slot.quantity);
                if (slot.quantity <= 0)
                {
                    slot.item = null;
                    slot.quantity = 0;
                    OnInventoryChanged?.Invoke(i, null, 0);
                }
            }
        }

        private int FillExistingStacks(ItemSO item, int amount)
        {
            for (int i = 0; i < itemSlots.Length && amount > 0; i++)
            {
                ItemSlot slot = itemSlots[i];

                if (slot.IsEmpty || slot.item.itemID != item.itemID || slot.IsFull) continue;

                int availableSpace = item.maxStackSize - slot.quantity;
                int quantityToAdd = Mathf.Min(availableSpace, amount);

                slot.quantity += quantityToAdd;
                amount -= quantityToAdd;
                AddToDictionary(item, quantityToAdd);
                OnInventoryChanged?.Invoke(i, item.itemIcon, slot.quantity);
            }
            return amount;
        }
        
        private int FillEmptySlots(ItemSO item, int amount)
        {
            for (int i = 0; i < itemSlots.Length && amount > 0; i++)
            {
                ItemSlot slot = itemSlots[i];
                if (!slot.IsEmpty) continue;
                int quantityToAdd = item.isStackable ? Mathf.Min(item.maxStackSize, amount) : 1;
                slot.item = item;
                slot.quantity = quantityToAdd;
                amount -= quantityToAdd;
                AddToDictionary(item, quantityToAdd);
                OnInventoryChanged?.Invoke(i, item.itemIcon, slot.quantity);
            }
            return amount;
        }


        private void AddToDictionary(ItemSO item, int quantity)
        {
            if (itemDictionary.ContainsKey(item.itemID))
            {
                itemDictionary[item.itemID] += quantity;
            }
            else
            {
                itemDictionary.Add(item.itemID, quantity);
            }
        }

        private void RemoveFromDictionary(ItemSO item, int quantity)
        {
            if (itemDictionary.ContainsKey(item.itemID))
            {
                itemDictionary[item.itemID] -= quantity;
                if (itemDictionary[item.itemID] <= 0)
                {
                    itemDictionary.Remove(item.itemID);
                }
            }
        }
    }
