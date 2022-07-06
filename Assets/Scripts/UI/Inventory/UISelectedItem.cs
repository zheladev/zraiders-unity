using UnityEngine;
using UnityEngine.UI;

public class UISelectedItem : MonoBehaviour
{
    public bool isItemSelected;
    private Image selectedItemSprite;
    private Item selectedItem;
    
    private UIInventorySlot _selectedItemUIInventorySlot;
    public UIInventorySlot selectedItemUIInventorySlot 
    {
        get { return _selectedItemUIInventorySlot; }
        set { _selectedItemUIInventorySlot = value; }
    }

    void Awake()
    {
        selectedItemSprite = GetComponent<Image>();
        UpdateItem(null);
    }

#nullable enable
    public void UpdateItem(Item? i)
    {
        selectedItem = i;
        if (selectedItem == null)
        {
            isItemSelected = false;
            selectedItemSprite.color = Color.clear;
        }
        else
        {
            isItemSelected = true;
            selectedItemSprite.color = Color.white;
            selectedItemSprite.sprite = i!.sprite;
        }
    }
}
