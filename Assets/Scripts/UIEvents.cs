using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour {

	public Button ButtonNext, ButtonQuitToMenu, ButtonResume, ButtonAboutOpen, ButtonAboutBack;
	public GameObject PanelMaine, PanelAbout;

	// Use this for initialization
	void Start () {

		if (ButtonNext != null) {
			Button btnNextComp = ButtonNext.GetComponent<Button> ();
			btnNextComp.onClick.AddListener (delegate {
				LevelSwitch (1);
			});
		};
		if (ButtonQuitToMenu != null) {
			Button btnQuitComp = ButtonQuitToMenu.GetComponent<Button> ();
			btnQuitComp.onClick.AddListener (delegate {
				LevelSwitch (0);
			});
		};


	}

	void LevelSwitch(int levelIndex){
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (levelIndex);
	}

}
