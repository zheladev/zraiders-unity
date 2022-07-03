

public class InventoryPayload
{
    public readonly int inventorySlot;
    public readonly Item item;

    public InventoryPayload(Item i, int invSlot)
    {
        inventorySlot = invSlot;
        item = i;
    }


}
