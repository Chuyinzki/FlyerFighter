using UnityEngine;
using System.Collections;

public class GateNumDisplay : MonoBehaviour {

	public GUIText gateNumText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mainMenu.levelLoaded) {
			gateNumText.text = ("Gates Remaining: " + mainMenu.numOfGates);
		}
	}
}
