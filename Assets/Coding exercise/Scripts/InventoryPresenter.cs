using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPresenter : MonoBehaviour
{
    InventoryModel inventoryModel;
   [SerializeField] private InventoryView inventoryView;
    private CraftingManager craftingManager;
    





    // For testing purposes
    [SerializeField] private int quantityToAdd = 1;
    public List<CraftingRecipe> craftingRecipes;
    public ItemSO testItem;
    void Start()
    {
        inventoryModel = new InventoryModel(20);
        craftingManager = new CraftingManager();
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
           craftingManager.CraftItem(craftingRecipes[0], inventoryModel);
        }
    }

    public void AddItem(ItemSO item, int quantity)
    {
        inventoryModel.AddItem(item, quantity);
    }

    public void RemoveItem(ItemSO item, int quantity)
    {
        inventoryModel.RemoveItem(item, quantity);
    }

    public void SetView(int index, Sprite sprite, int ammount)
    {
        inventoryView.UpdateInventoryUI(index, sprite, ammount);
    }
}