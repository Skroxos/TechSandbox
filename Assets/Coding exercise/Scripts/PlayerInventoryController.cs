using UnityEngine;
using VContainer;

public class PlayerInventoryController : MonoBehaviour
{
    private InventoryModel inventoryModel;

    // Testing purposes
    public ItemSO exampleItem;
    public int exampleQuantity = 1;

    [Inject]
    public void Construct(InventoryModel model)
    {
        inventoryModel = model;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventoryModel.AddItem(exampleItem, exampleQuantity);
        }
    }
}