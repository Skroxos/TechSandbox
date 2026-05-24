using System;
using UnityEngine;
using VContainer.Unity;

public class InventoryPresenter : IDisposable, IInitializable
{
    private readonly InventoryModel inventoryModel;
    private readonly InventoryView inventoryView;
 


    public InventoryPresenter(InventoryView view, InventoryModel model)
    {
        inventoryModel = model;
        inventoryView = view;
    }
    public void Initialize()
    {
        inventoryModel.OnInventoryChanged += SetView;

    }

    public void Dispose()
    {
        inventoryModel.OnInventoryChanged -= SetView;

    }

    public void SetView(int index, Sprite sprite, int ammount)
    {
        inventoryView.UpdateInventoryUI(index, sprite, ammount);
    }


}
