using System.Collections.Generic;

public class InventorySystem
{
    public List<Item> items;
    public int slots;

    public InventorySystem()
    {
        items = new List<Item>();
        slots = 37 * 7;
    }

    public void AddItem(Item item, int id)
    {
        //check if valid id
        if (id >= items.Count || id < 0) return;

        //TODO: check if inventory full
        if (item.isStackable)
        {
            Item _item = items.Find(i => item.id == i.id);
            //TODO: will give issues when swapping around with stackable items
            if (_item != null)
            {
                _item.stackSize += 1;
            }
            else
            {
                items[id] = item;
            }
        }
        else
        {
            items[id] = item;
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
