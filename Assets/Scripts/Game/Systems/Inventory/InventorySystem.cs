using System.Collections.Generic;

public class InventorySystem
{
    public List<Item> items;
    public int slots;

    public InventorySystem()
    {
        items = new List<Item>();
        slots = 191;
    }

    public void AddItem(ItemDefinition iDef)
    {
        //TODO: check if inventory full
        if (iDef.isStackable)
        {
            Item _item = items.Find(i => i.id == iDef.id);
            if (_item != null)
            {
                _item.stackSize += 1;
            }
            else
            {
                items.Add(new Item(iDef));
            }
        }
        else
        {
            items.Add(new Item(iDef));
        }
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);
        }
    }
}
