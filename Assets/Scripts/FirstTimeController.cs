using UnityEngine;
using UnityEngine.UI;

public class FirstTimeController : Controller {
	public InputField NameField;
	
	public GameIntroController GameIntroController;
	string cachedName = "";

	public void OnSubmitName() {
		cachedName = NameField.text;
		
		if(cachedName.Length > 0) {
			PlayerData.name = cachedName;
			
			GameIntroController.OnFinishFirstTime();
		}
	}
}
