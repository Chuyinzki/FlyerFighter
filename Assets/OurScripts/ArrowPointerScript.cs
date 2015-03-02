using UnityEngine;
using System.Collections;

public class ArrowPointerScript : MonoBehaviour {

	public GameObject wayFinder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mainMenu.levelLoaded) {
			if(mainMenu.numOfGates  > 0)
			{
				wayFinder.transform.LookAt(mainMenu.positionList[mainMenu.positionListIndex], wayFinder.transform.up);
				Debug.Log (mainMenu.positionList[mainMenu.positionListIndex]);
			}
		}

	}
}
