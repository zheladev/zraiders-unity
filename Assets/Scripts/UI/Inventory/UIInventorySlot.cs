using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    public Item item;
    private Image spriteImage;
    // Start is called before the first frame update
    void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    // Update is called once per frame
    public void UpdateItem(Item i)
    {
        item = i;
        if (item == null)
        {
            spriteImage.color = Color.clear;
        }
        else
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.sprite;
        }
    }
}
