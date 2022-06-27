using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
	public Button startButton;
	public UIActions actions;

	void Start () {
		if (!actions) actions = GameObject.FindWithTag(GameObjectTags.UI_ACTIONS).GetComponent(typeof (UIActions)) as UIActions;
		Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(Action);
	}

	void Action(){ 
		DataManagerSingleton.Instance.enemies[0] = "asdasd"; //test
		actions.StartRaid();
	}
}
