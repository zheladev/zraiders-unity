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


    private ItemDefinition(string name, string description, int tier, ItemRarity rarity, string spriteName)
    {
        this.name = name;
        this.description = description;
        this.tier = tier;
        this.rarity = rarity;
        this.sprite = Resources.Load<Sprite>($"Sprites/Items/{spriteName}");
        this.id = ItemDefinition.idCount++;
    }

    //TODO: stats
    public static ItemDefinition GenItem(string name, string description, int tier, ItemRarity rarity, string spriteName)
    {
        return new ItemDefinition(name, description, tier, rarity, spriteName);
    }
}
