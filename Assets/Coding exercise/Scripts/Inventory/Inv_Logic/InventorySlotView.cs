using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotView : MonoBehaviour
{
     private Image itemImage;
     private TextMeshProUGUI quantityText;

    private void Start()
    {
        itemImage = GetComponent<Image>();
        quantityText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateSlot(Sprite sprite, int quantity)
    {
        if (quantity == 0) {
            itemImage.sprite = null;
            quantityText.text = "";
            return;
        }
        itemImage.sprite = sprite;
        quantityText.text = quantity > 1 ? quantity.ToString() : "";
    }
}
