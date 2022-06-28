using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseActionButton : BaseButton
{
    // Start is called before the first frame update
    public UIActions actions;

    void Start()
    {
        if (!actions) actions = GameObject.FindWithTag(GameObjectTags.UI_ACTIONS).GetComponent(typeof(UIActions)) as UIActions;
        button.onClick.AddListener(Action);
    }

    protected abstract void Action();
}
