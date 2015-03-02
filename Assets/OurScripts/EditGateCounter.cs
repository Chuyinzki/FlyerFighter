using UnityEngine;
using System.Collections;

public class EditGateCounter : MonoBehaviour {

	public GUIText gCounter;

	// Use this for initialization
	void Start () {
		gCounter.text = "Number of Gates: " + Move_Script.createdGateCounter;
	}
	
	// Update is called once per frame
	void Update () {
		gCounter.text = "Number of Gates: " + Move_Script.createdGateCounter;
	}
}
