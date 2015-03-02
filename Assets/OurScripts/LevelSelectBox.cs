using UnityEngine;
using System.Collections;

public class LevelSelectBox : MonoBehaviour {

	private Color originalColor;
	static public int index = 0;
	static public int howManyFiles;
	static public bool filesLoaded = false;
	bool loaded = false;
	
	void OnTriggerEnter(Collider other)
	{
		originalColor = renderer.material.color;
		renderer.material.color= new Color(0.5f,1,1);
		Debug.Log ("Object Entered the trigger");
		//Debug.Log ("Length of FileSize: " + howManyFiles);
	}
	
	void OnTriggerStay(Collider other)
	{
		if (RaiseHandDetector.setBool && !loaded) {
			mainMenu.levelSelected = index;
			Application.LoadLevel (2);
			loaded = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		renderer.material.color = originalColor;
		Debug.Log ("Object Exited the trigger");
	}
	
	
	// Use this for initialization
	void Start () {
		//howManyFiles = FileParser.filePaths.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (FileParser.parseDone && !filesLoaded) {
			howManyFiles = FileParser.filePaths.Length;
			//Debug.Log("Number of files:" + howManyFiles);
			filesLoaded = true;
		}
	}
}
