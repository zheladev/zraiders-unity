
public class Item : ItemDefinition
{
    public int stackSize;

    public Item(string name, string description, int tier, ItemRarity rarity, bool isStackable, string spriteName) : 
    base(name, description, tier, rarity, isStackable, spriteName)
    {
        stackSize = 1;
    }

    public Item(ItemDefinition idef) :
    base(idef)
    {
        stackSize = 1;
    }
}
