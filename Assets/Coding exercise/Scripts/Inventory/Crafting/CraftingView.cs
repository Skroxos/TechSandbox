using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftingView : MonoBehaviour
{
    [SerializeField] private CraftingSlotView slotPrefab;
    [SerializeField] private Transform slotsContainer;

    [SerializeField] private List<CraftingRecipe> availableRecipes;

    private readonly List<CraftingSlotView> activeSlots = new();

    public event Action<CraftingRecipe> OnRecipeCraftRequest;

    public void InitializeSlots()
    {
        foreach (var recipe in availableRecipes)
        {
            var slot = Instantiate(slotPrefab, slotsContainer);
            slot.Setup(recipe);
            slot.OnCraftClicked += HandleSlotClicked;
            activeSlots.Add(slot);
        }
    }

    private void HandleSlotClicked(CraftingRecipe recipe)
    {
        OnRecipeCraftRequest?.Invoke(recipe);
    }

    public void UpdateSlotStates(Func<CraftingRecipe, bool> canCraftCheck)
    {
        for (int i = 0; i < activeSlots.Count; i++)
        {
            bool isCraftable = canCraftCheck(availableRecipes[i]);
            activeSlots[i].SetInteractable(isCraftable);
        }
    }
}