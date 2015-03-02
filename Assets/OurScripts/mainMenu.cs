using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class mainMenu : MonoBehaviour {

	static public List<List<float>> files = new List<List<float>>();
	static public bool readyToStart = false;
	static public bool playMode = false;
	static public int levelSelected;
	static public int numOfGates;

	static public List<Vector3> positionList = new List<Vector3> ();
	static public int positionListIndex = 0;

	static public bool levelLoaded;

	public bool gameModeSelected = false;
	public GameObject myPrefab;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(!levelLoaded && FileParser.parseDone) loadLevel();
		//if (!gameModeSelected) 
	}

	void loadLevel(){

		List<float> portals = files[levelSelected];
		for(int p = 0; p < portals.Count; p+=9){
			//Debug.Log ("Portal Count: " + portals.Count);
			Vector3 pos = new Vector3(portals[p], portals[p+1], portals[p+2]);

			positionList.Add (pos);

			Vector3 rightVect = new Vector3(portals[p+3], portals[p+4], portals[p+5]);
			Vector3 upVect = new Vector3(portals[p+6], portals[p+7], portals[p+8]);

			GameObject myGameObj = (GameObject) Instantiate(myPrefab);
			myGameObj.transform.position = pos;

			Vector3 forwardVect = Vector3.Cross (rightVect, upVect);

			myGameObj.transform.rotation = Quaternion.LookRotation(forwardVect, upVect);
			myGameObj.transform.rotation.SetFromToRotation(myGameObj.transform.right, rightVect);
			numOfGates++;



			//Debug.Log("Portal #" + (p+9)/9 + " created!");
			                        
		}
		levelLoaded = true;

	}
}
