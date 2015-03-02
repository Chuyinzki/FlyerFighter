using UnityEngine;
using System.Collections;

public class ActiveEditMode : MonoBehaviour {

	private Color originalColor;
	bool canLoad = false;
	
	void OnTriggerEnter(Collider other)
	{
		originalColor = renderer.material.color;
		renderer.material.color= new Color(0.5f,1,1);
		//Debug.Log ("Object Entered the trigger");
	}
	
	void OnTriggerStay(Collider other)
	{
		if (RaiseHandDetector.setBool) {
			Application.LoadLevel (3);
		}

		//Application.LoadLevel (2);
		//Debug.Log ("Object is within trigger");
	}
	
	void OnTriggerExit(Collider other)
	{
		renderer.material.color = originalColor;
		//Debug.Log ("Object Exited the trigger");
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
