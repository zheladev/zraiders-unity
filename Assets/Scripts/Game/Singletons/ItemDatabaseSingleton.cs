using System.Collections.Generic;
using System;

public class ItemDatabaseSingleton
{
    /// <summary>Static reference to the instance of our DataManager</summary>
    static ItemDatabaseSingleton _instance = null;
    static readonly object _padlock = new object();

    public List<ItemDefinition> items;

    private ItemDatabaseSingleton()
    {
        BuildDatabase();
    }

    public static ItemDatabaseSingleton Instance
    {
        get
        {
            lock (_padlock)
            {
                if (_instance == null)
                {
                    _instance = new ItemDatabaseSingleton();
                }

                return _instance;
            }
        }
    }

    private void BuildDatabase()
    {
        this.items = new List<ItemDefinition> {
            new ItemDefinition("test", "test desc", 0, ItemRarity.Uncommon, true, "lol"),
            new ItemDefinition("test2", "test desc", 0, ItemRarity.Uncommon, true, "lol2"),
        };
    }

#nullable enable
    public Item? GetItemById(int id)
    {
        ItemDefinition? _idef = this.items.Find(i => i.id == id);
        return _idef == null ? null : new Item(_idef);
    }

    public Item? GetItemByName(string name)
    {
        ItemDefinition? _idef = this.items.Find(i => i.name == name);
        return _idef == null ? null : new Item(_idef);
    }
#nullable disable

    public List<Item> GetItemsByTier(int tier)
    {
        return this.items.FindAll(i => i.tier == tier).ConvertAll(
            new Converter<ItemDefinition, Item>(idef => new Item(idef))
        );
    }
}
