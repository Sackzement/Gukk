using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ResolutionsDropdown : MonoBehaviour {

	Dropdown dd;
	Resolution[] resolutions;



	// Use this for initialization
	void Start () {
		dd = GetComponent<Dropdown> ();	
		dd.ClearOptions ();
		resolutions = Screen.resolutions;

		List<Dropdown.OptionData> list = new List<Dropdown.OptionData>();

		foreach (Resolution res in resolutions) {
			Dropdown.OptionData data = new Dropdown.OptionData();
			data.text = res.width + " x " + res.height + " | " + res.refreshRate;
			list.Add(data);
		}

		dd.AddOptions (list);

		// get idx of curr res
		int i = 0;
		bool found = false;
		for (; i < resolutions.Length; ++i) {
			if (Screen.currentResolution.Equals (resolutions [i])) {
				found = true;
				break;
			}
		}
		if (found) {
			dd.value = i;
		}
		dd.RefreshShownValue ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
