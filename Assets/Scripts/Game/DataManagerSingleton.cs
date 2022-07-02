using UnityEngine;
/// <summary>Manages data for persistance between levels.</summary>
public class DataManagerSingleton
{
    /// <summary>Static reference to the instance of our DataManager</summary>
    static DataManagerSingleton _instance = null;
    static readonly object _padlock = new object();

    /// <summary>The player's current score.</summary>
    public string[] raiders = new string[] {
        "Warrior1",
        "Warrior2",
        "Warrior3"
    };
    public string[] enemies = new string[] {
        "Enemy1"
    };

    public EncounterData currentEncounter;

    /// <summary>Awake is called when the script instance is being loaded.</summary>
    public static DataManagerSingleton Instance {
        get {
            lock (_padlock) {
                if (_instance == null) {
                    _instance = new DataManagerSingleton();
                }

                return _instance;
            }
        }
    }
}
