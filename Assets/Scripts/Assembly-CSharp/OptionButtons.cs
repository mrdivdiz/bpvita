using UnityEngine;

public class OptionButtons : SliderButton
{
	private GameObject LoadButtonToOptions(string name, string methodToInvoke)
	{
		GameObject original = (GameObject)Resources.Load("OptionButtons/" + name.ToString());
		GameObject gameObject = GameObject.Find("InfoButtons");
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(original);
		gameObject2.transform.parent = gameObject.transform;
		gameObject2.name = name;
		gameObject2.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 0.5f);
		if (!string.IsNullOrEmpty(methodToInvoke))
		{
			gameObject2.GetComponent<Button>().MethodToCall.SetMethod(GameObject.Find("MainMenuLogic").GetComponent<MainMenu>(), methodToInvoke);
		}
		return gameObject2;
	}
}
