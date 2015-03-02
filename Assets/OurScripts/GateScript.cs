using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {

	private int intGateTimer = 0;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Gate touched something");
	}
	
	void OnTriggerStay(Collider other)
	{
		//intGateTimer++;
		//if (intGateTimer == 7) {
			if(this.transform.parent.position == mainMenu.positionList[mainMenu.positionListIndex] &&
			   mainMenu.levelLoaded)
			{
				mainMenu.numOfGates--;
				mainMenu.positionListIndex++;
				//intGateTimer = 0;
				Destroy (this.transform.parent.gameObject);
			}

		//}
		Debug.Log ("Gate still something");
	}
	
	void OnTriggerExit(Collider other)
	{
		Debug.Log ("Gate exited something");
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
