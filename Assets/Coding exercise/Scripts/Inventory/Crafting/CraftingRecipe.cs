using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "Inventory/Crafting Recipe")]
public sealed class CraftingRecipe : ScriptableObject
{
    public ItemSO resultItem;
    public List<CraftingRequirement> requiredItems;
    public int craftedQuantity = 1;

}
