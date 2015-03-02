using UnityEngine;
using System.Collections;

public class LeftSelector : MonoBehaviour {

	private Color originalColor;
	bool handStillRaised = true;
	
	void OnTriggerEnter(Collider other)
	{
		originalColor = renderer.material.color;
		renderer.material.color= new Color(0.5f,1,1);
		Debug.Log ("Object Entered the trigger");
	}
	
	void OnTriggerStay(Collider other)
	{
		if (RaiseHandDetector.setBool && LevelSelectBox.filesLoaded && !handStillRaised) {
			handStillRaised = true;
			if(LevelSelectBox.index-1 < 0)
			{
				LevelSelectBox.index = LevelSelectBox.howManyFiles-1;
			}
			else
			{
				LevelSelectBox.index--;
			}
			Debug.Log ("Index: " + LevelSelectBox.index);
			//Application.LoadLevel (1);
		}

		if (!RaiseHandDetector.setBool && handStillRaised) {
			handStillRaised = false;
			}
	}
	
	void OnTriggerExit(Collider other)
	{
		renderer.material.color = originalColor;
		handStillRaised = false;
		Debug.Log ("Object Exited the trigger");
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
