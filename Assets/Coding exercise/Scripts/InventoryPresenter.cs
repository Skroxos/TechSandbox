using System.Collections.Generic;
using UnityEngine;

public class InventoryPresenter : MonoBehaviour
{
    InventoryModel inventoryModel;
   [SerializeField] private InventoryView inventoryView;
    [SerializeField] private int quantityToAdd = 1;
    public ItemSO testItem;
    void Start()
    {
        inventoryModel = new InventoryModel(20);
        inventoryModel.OnInventoryChanged += SetView;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddItem(testItem, quantityToAdd);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(inventoryModel.HasItem(1))
            {
                Debug.Log("Item with ID 1 is in the inventory.");
            }
        }
    }

    public void AddItem(ItemSO item, int quantity)
    {
        inventoryModel.AddItem(item, quantity);
    }

    public void RemoveItem(ItemSO item)
    {
        inventoryModel.RemoveItem(item);
    }

    public void SetView(int index, Sprite sprite, int ammount)
    {
        inventoryView.UpdateInventoryUI(index, sprite, ammount);
    }
}