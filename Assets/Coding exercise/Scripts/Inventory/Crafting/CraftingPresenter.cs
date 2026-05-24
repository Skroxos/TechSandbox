using System;
using UnityEngine;
using VContainer.Unity;

public class CraftingPresenter : IDisposable, IInitializable
{
        private readonly CraftingModel craftingModel;
        private readonly CraftingView view;
        private readonly InventoryModel inventory;

    public CraftingPresenter(CraftingModel craftingModel, CraftingView view, InventoryModel inventory)
    {
        this.craftingModel = craftingModel;
        this.view = view;
        this.inventory = inventory;
    }


    public void Initialize()
    {
        view.InitializeSlots();
        view.OnRecipeCraftRequest += HandleCraftRequest;
        inventory.OnInventoryChanged += RefreshUI;
        RefreshUI(0, null, 0);
    }


    public void Dispose()
    {
        view.OnRecipeCraftRequest -= HandleCraftRequest;
        inventory.OnInventoryChanged -= RefreshUI;
    }

    private void HandleCraftRequest(CraftingRecipe recipe)
    {
        craftingModel.CraftItem(recipe);
    }
    
    private void RefreshUI(int arg1, Sprite sprite, int arg3)
    {
      view.UpdateSlotStates(craftingModel.CanCraft);
    }
}