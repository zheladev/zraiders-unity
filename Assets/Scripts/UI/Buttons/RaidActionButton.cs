using UnityEngine;
using UnityEngine.UI;

public class RaidActionButton : BaseActionButton
{
    protected override void Action()
    {
        Debug.Log(DataManagerSingleton.Instance.enemies[0]);
        DataManagerSingleton.Instance.enemies[0] = "asdasd"; //test
        actions.StartRaid();
    }
}
