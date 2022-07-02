using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    #nullable enable
    public ItemDefinition? GetItemById(int id) 
    {
        return this.items.Find(i => i.id == id);
    }

    public ItemDefinition? GetItemByName(string name)
    {
        return this.items.Find(i => i.name == name);
    }
    #nullable disable

    public List<ItemDefinition> GetItemsByTier(int tier)
    {
        return this.items.FindAll(i => i.tier == tier);
    }

    private void BuildDatabase()
    {
        this.items = new List<ItemDefinition> {
        ItemDefinition.GenItem("test", "test desc", 0, ItemRarity.Uncommon, "lol"),
        ItemDefinition.GenItem("test2", "test desc", 0, ItemRarity.Uncommon, "lol2"),
    };
    }
}
