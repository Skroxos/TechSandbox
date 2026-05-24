public class CraftingModel
{
    private readonly InventoryModel inventory;

    public CraftingModel(InventoryModel inventory)
    {
        this.inventory = inventory;
    }
    public bool CanCraft(CraftingRecipe recipe)
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
    public void CraftItem(CraftingRecipe recipe)
    {
        if (CanCraft(recipe))
        {
            foreach (var requirement in recipe.requiredItems)
            {
                inventory.RemoveItem(requirement.item, requirement.quantity);
            }
            inventory.AddItem(recipe.resultItem, recipe.craftedQuantity);
        }
    }
}
