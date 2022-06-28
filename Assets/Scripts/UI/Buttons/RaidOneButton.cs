using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidOneButton : BaseActionButton
{
    protected override void Action()
    {
        //DataManagerSingleton.Instance.enemies[0] = "asdasd"; //test
        actions.StartRaid();
    }
}
