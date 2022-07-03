using UnityEngine;
using UnityEngine.UI;

public class UISelectedItem : MonoBehaviour
{
    public bool isItemSelected;
    private Image selectedItemSprite;
    private Item selectedItem;

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
