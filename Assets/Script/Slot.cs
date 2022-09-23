using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Item item;
    public GameObject ItemImage;
    private Image itemIcon;
    private TextMeshProUGUI textMeshProUGUI;
    private Inventory inventory;

    private void Awake()
    {
        itemIcon = ItemImage.GetComponent<Image>();
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        inventory = GetComponentInParent<Inventory>();
    }


    private int itemCount;
    public void UpdateSlotUI(int index)
    {
        //Debug.Log($"{ItemDB.instance.itemDB[i].itemImage.name}");
        //itemIcon.sprite = item.itemImage;
        //Debug.Log(ItemDB.instance.itemDB[index].itemImage);
        
        itemIcon.sprite = ItemDB.instance.itemDB[index].itemImage;
        //itemCount = Inventory.inventory.item_dic[ItemDB.instance.itemDB[index].itemName];
        itemCount = inventory.item_dic[ItemDB.instance.itemDB[index].itemName];
        textMeshProUGUI.text = itemCount.ToString();
    }
}
