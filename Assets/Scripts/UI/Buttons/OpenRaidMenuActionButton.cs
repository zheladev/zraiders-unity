using UnityEngine;
using UnityEngine.UI;

public class OpenRaidMenuActionButton : BaseActionButton
{
    protected override void Action()
    {
        //DataManagerSingleton.Instance.enemies[0] = "asdasd"; //test
        actions.ToggleRaidPanelCanvasGroup();
    }
}
