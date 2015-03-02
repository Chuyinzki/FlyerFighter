using UnityEngine;
using System.Collections;

public class FileDisplayNum : MonoBehaviour {

	public GUIText fileText;

	// Use this for initialization
	void Start () {
		fileText.text = ("File Selected: ");
	}
	
	// Update is called once per frame
	void Update () {
		if (FileParser.parseDone) {
			fileText.text = ("File Selected: " + FileParser.filePaths[LevelSelectBox.index]);
		}

	}
}
