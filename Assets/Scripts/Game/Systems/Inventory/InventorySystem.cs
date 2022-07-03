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

    public void AddItem(Item item)
    {
        //TODO: check if inventory full
        if (item.isStackable)
        {
            Item _item = items.Find(i => item.id == i.id);
            if (_item != null)
            {
                _item.stackSize += 1;
            }
            else
            {
                items.Add(new Item(item));
            }
        }
        else
        {
            items.Add(new Item(item));
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
