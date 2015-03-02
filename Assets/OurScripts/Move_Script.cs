using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move_Script : MonoBehaviour {
	static public int createdGateCounter = 0;

	public GameObject head;
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject leftShoulder;
	public GameObject rightShoulder;

	public GameObject Gate;

	List<GameObject> gateList = new List<GameObject> ();

	float metersPerHour;
	float speed;
	Vector3 pos;
	Vector3 temp;

	int numGatesDropped = 0;

	// Use this for initialization
	void Start () {
		metersPerHour = 50000;
		speed = (((metersPerHour / 60) / 60) / 60); 
		pos = this.transform.localPosition;
		temp.Set(0, 0, speed);

	}
	
	// Update is called once per frame
	void Update () {
		/*if(mainMenu.readyToStart)*/ pos.z += speed;
		//Debug.Log (speed);
		/*if(mainMenu.readyToStart)*/this.transform.Translate(temp);

		//////////////////////////ROTATION CONTROL Z -- PITCH /////////////////////////////////////////////////////

		//if ((head.transform.position.z - rightHand.transform.position.z > 2) && (head.transform.position.z - leftHand.transform.position.z > 2)) {

		if((leftHand.transform.position.z - leftShoulder.transform.position.z > 4.5) &&
		   (rightHand.transform.position.z - rightShoulder.transform.position.z > 4.5) /*&& mainMenu.readyToStart*/){	
			transform.Rotate (new Vector3(0.75f,0,0));
			//Debug.Log ("Left Shoulder Z is: " + leftShoulder.transform.position.z);
			//Debug.Log ("Left Hand Z is: " + leftHand.transform.position.z);
		}

		else if((leftHand.transform.position.z - leftShoulder.transform.position.z < 2.5) &&
		        (rightHand.transform.position.z - rightShoulder.transform.position.z < 2.5) /*&& mainMenu.readyToStart*/){	
			transform.Rotate (new Vector3(-0.75f,0,0));
			//Debug.Log ("Left Shoulder Z is: " + leftShoulder.transform.position.z);
			//Debug.Log ("Left Hand Z is: " + leftHand.transform.position.z);
		}
		//Debug.Log ("Distance is: " + (leftHand.transform.position.z - leftShoulder.transform.position.z));


		//////////////////////////ROTATION CONTROL Y -- YAW /////////////////////////////////////////////////////
		if (leftHand.transform.position.z - rightHand.transform.position.z > 1.5 /*&& mainMenu.readyToStart*/) {
			transform.Rotate (new Vector3(0,0.75f,0));
		}

		else if (rightHand.transform.position.z - leftHand.transform.position.z > 1.5 /*&& mainMenu.readyToStart*/) {
			transform.Rotate (new Vector3(0,-0.75f,0));
		}

		//////////////////////////ROTATION CONTROL X -- ROLL /////////////////////////////////////////////////////
		if (rightHand.transform.position.y - leftHand.transform.position.y > 2 /*&& mainMenu.readyToStart*/) {
			transform.Rotate (new Vector3(0,0,1));
		}
		else if (leftHand.transform.position.y - rightHand.transform.position.y > 2 /*&& mainMenu.readyToStart*/) {
			transform.Rotate (new Vector3(0,0,-1));
		}

		//if (RaiseHandDetector.undoBool) {
		//	RaiseHandDetector.undoBool = false;

		//	Application.Quit();
		//}

		if (Input.GetKeyUp(KeyCode.Space) && !mainMenu.playMode) {
			createdGateCounter++;
			numGatesDropped += 1;

			GameObject tempGate =  (GameObject) Instantiate (Gate);
			tempGate.transform.position = this.transform.position;
			//tempGate.transform.rotation = this.transform.rotation;

			//Debug.Log ("Potensh Output: " + tempGate.transform.position + " " + tempGate.transform.right + " " + tempGate.transform.up);

			tempGate.transform.rotation = Quaternion.LookRotation (this.transform.forward, this.transform.up);
			float tempAngle = Vector3.Angle (tempGate.transform.right, this.transform.right);
			//tempGate.transform.Rotate (new Vector3(0, 0,tempAngle));
			tempGate.transform.rotation.SetFromToRotation (tempGate.transform.right, this.transform.right);


			//tempGate.transform.up = this.transform.up;
			//tempGate.transform.right = this.transform.right;
			//tempGate.transform.forward = this.transform.forward;
			//tempGate.transform.up = new Vector3(-4.596951f, -1.914752f, -0.449187f);
			//tempGate.transform.right = new Vector3(0.950578f, -2.016893f, -1.130727f);
			//Debug.Log ("Right vector in world space: " + tempGate.transform.right);
			//Debug.Log ("X: " + this.transform.rotation.eulerAngles.x);
			//Debug.Log ("Y: " + this.transform.rotation.eulerAngles.y);
			//Debug.Log ("Z: " + this.transform.rotation.eulerAngles.z);
			gateList.Add (tempGate);

			if (numGatesDropped >= 10){
				//write gates to file
				//string path = @"C:\Users\Jimmy\Desktop\storedGames\yourCustomLevel.txt";
				string path = Application.dataPath + "/storedGames/yourCustomLevel.txt";
				string text = "";

				for(int i = 0; i < gateList.Count; i++){
					//write Gate in
					float cx = gateList[i].transform.position.x;
					float cy = gateList[i].transform.position.y;
					float cz = gateList[i].transform.position.z;
					float rx = gateList[i].transform.right.x;
					float ry = gateList[i].transform.right.y;
					float rz = gateList[i].transform.right.z;
					float ux = gateList[i].transform.up.x;
					float uy = gateList[i].transform.up.y;
					float uz = gateList[i].transform.up.z;

					string line = (cx + " " + cy + " " + cz + " " +
							rx + " " + ry + " " + rz + " " +
							ux + " " + uy + " " + uz + "\n");
					text = text + line;
					//file.WriteLine(line);

				}
				System.IO.File.WriteAllText(path, text);
				//quit
			}



	
		}
	
	}
}
