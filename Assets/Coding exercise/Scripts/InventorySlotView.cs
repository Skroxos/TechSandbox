using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
     private Image itemImage;
     private TMPro.TextMeshProUGUI quantityText;

    private void Start()
    {
        itemImage = GetComponent<Image>();
        quantityText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    public void UpdateSlot(Sprite sprite, int quantity)
    {
        itemImage.sprite = sprite;
        quantityText.text = quantity > 1 ? quantity.ToString() : "";
    }
}
