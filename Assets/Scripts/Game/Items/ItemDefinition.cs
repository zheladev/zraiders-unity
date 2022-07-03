using UnityEngine;

public class ItemDefinition
{
    public static int idCount;
    public readonly int id;
    public readonly string name;
    public readonly string description;
    public readonly int tier;
    public readonly ItemRarity rarity;
    public readonly Sprite sprite;
    public readonly bool isStackable;

    public ItemDefinition(string name, string description, int tier, ItemRarity rarity, bool isStackable, string spriteName)
    {
        this.name = name;
        this.description = description;
        this.tier = tier;
        this.rarity = rarity;
        this.sprite = Resources.Load<Sprite>($"Sprites/Items/{spriteName}");
        this.id = idCount++;
        this.isStackable = isStackable;
    }

    public ItemDefinition(ItemDefinition idef)
    {
        this.name = idef.name;
        this.description = idef.description;
        this.tier = idef.tier;
        this.rarity = idef.rarity;
        this.sprite = idef.sprite;
        this.id = idef.id;
        this.isStackable = idef.isStackable;
    }
}
