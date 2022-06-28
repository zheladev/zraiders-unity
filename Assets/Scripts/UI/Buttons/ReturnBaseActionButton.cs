using UnityEngine;

public class ReturnBaseActionButton : BaseActionButton {

	protected override void Action()
	{
		DataManagerSingleton.Instance.enemies[0] = $"returning{Random.Range(1, 10)}"; //test
		actions.ReturnToBase();
	}
}
