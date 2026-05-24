using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifeTimeScope : LifetimeScope
{
    [SerializeField] private InventoryView inventoryView;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInventorySystem();
        builder.RegisterCraftingSystem();
        builder.RegisterComponent(inventoryView);

        builder.RegisterComponentInHierarchy<PlayerInventoryController>();
    }
}
