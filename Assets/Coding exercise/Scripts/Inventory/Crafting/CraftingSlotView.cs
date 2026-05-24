
using System;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlotView : MonoBehaviour
{
    //[SerializeField] private Image itemIcon;
    [SerializeField] private Button craftButton;
    private CraftingRecipe myRecipe;
    public event Action<CraftingRecipe> OnCraftClicked;

    private void Start()
    {
        craftButton.onClick.AddListener(() => OnCraftClicked?.Invoke(myRecipe));
    }

    public void Setup(CraftingRecipe recipe)
    {
        myRecipe = recipe;
      //  itemIcon.sprite = recipe.resultItem.itemIcon;
    }

    public void SetInteractable(bool canCraft)
    {
        craftButton.interactable = canCraft;
    }
}


