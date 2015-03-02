using UnityEngine;
using System.Collections;

public class Jet_Control : MonoBehaviour {

	public GameObject leftHand;
	public GameObject rightHand;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (leftHand.transform.position.y - rightHand.transform.position.y > 10) {

		}

	}
}
