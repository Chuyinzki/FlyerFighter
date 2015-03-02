using UnityEngine;
using System.Collections;

public class ActivatePlayMode : MonoBehaviour {

	private Color originalColor;

	void OnTriggerEnter(Collider other)
	{
		originalColor = renderer.material.color;
		renderer.material.color= new Color(0.5f,1,1);
		Debug.Log ("Object Entered the trigger");
	}

	void OnTriggerStay(Collider other)
	{
		if (RaiseHandDetector.setBool) {
			Application.LoadLevel (1);
		}
	}

	void OnTriggerExit(Collider other)
	{
		renderer.material.color = originalColor;
		Debug.Log ("Object Exited the trigger");
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
