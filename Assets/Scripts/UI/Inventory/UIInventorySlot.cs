using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    public ItemDefinition itemDef;
    private Image spriteImage;
    // Start is called before the first frame update
    void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    // Update is called once per frame
    void UpdateItem(ItemDefinition idef)
    {
        this.itemDef = idef;
        if (this.itemDef == null)
        {
            
        }
    }
}
