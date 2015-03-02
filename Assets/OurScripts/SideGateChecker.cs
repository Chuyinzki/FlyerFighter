using UnityEngine;
using System.Collections;

public class SideGateChecker : MonoBehaviour {

	static public bool sideGateTouched = false;

	
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("Gate touched something");
	}
	
	void OnTriggerStay(Collider other)
	{
		//if (intGateTimer == 7) sideGateTouched = true;
		//Debug.Log ("Gate still something");
	}
	
	void OnTriggerExit(Collider other)
	{
		//Debug.Log ("Gate exited something");
	}


	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
