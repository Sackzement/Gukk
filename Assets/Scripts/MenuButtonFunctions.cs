using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtonFunctions : MonoBehaviour {

	public void loadScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void quitGame() {
		Application.Quit ();
	}

}
