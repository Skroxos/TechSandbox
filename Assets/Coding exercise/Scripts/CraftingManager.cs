using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class CraftingManager
{
    public bool CanCraft(CraftingRecipe recipe, InventoryModel inventory)
    {
        foreach (var requirement in recipe.requiredItems)
        {
            if (!inventory.HasItemForCrafting(requirement.item.itemID, requirement.quantity))
            {
                return false;
            }
        }
        return true;
    }
    public void CraftItem(CraftingRecipe recipe, InventoryModel inventory)
    {
        if (CanCraft(recipe, inventory))
        {
            foreach (var requirement in recipe.requiredItems)
            {
                inventory.RemoveItem(requirement.item, requirement.quantity);
            }
            inventory.AddItem(recipe.resultItem, recipe.craftedQuantity);
        }
    }
}

//public class GameLifeTimeScope : LifetimeScope
//{
//    protected override void Configure(IContainerBuilder builder)
//    {
//        builder.Register<InventoryModel>(Lifetime.Singleton);
//        builder.RegisterComponentInHierarchy<ScoreUploader>();
//    }
//}