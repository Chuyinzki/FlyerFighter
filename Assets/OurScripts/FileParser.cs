using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class FileParser : MonoBehaviour {
	static public Boolean parseDone = false;
	static public string[] filePaths;

	// Use this for initialization
	void Start () {
		string path = Application.dataPath + "/storedGames/";
		filePaths = Directory.GetFiles(path, "*.txt");
		//filePaths = Directory.GetFiles(@"C:\Users\Jimmy\Desktop\storedGames\", "*.txt");

		for (int i = 0; i < filePaths.Length; i++) {
			string p = filePaths[i];
			string line;
			List<float> allFloats = new List<float>();
			
			// Read the file and display it line by line.
			System.IO.StreamReader file = new System.IO.StreamReader(p);
			while((line = file.ReadLine()) != null)
			{
				//Debug.Log(line);
				string[] ssize = line.Split(' ');
				for(int o = 0; o < ssize.Length; o++){
					float number = Single.Parse(ssize[o]);
					allFloats.Add(number);
				}
			}
			mainMenu.files.Add(allFloats);
			file.Close ();
			//Debug.Log(p);
		}
		Debug.Log("Files read: " + mainMenu.files.Count);
		for (int g = 0; g < mainMenu.files.Count; g++) {
			//Debug.Log("File #" + g + " has " + mainMenu.files[g].Count/9 + " lines!");
		}

		parseDone = true;
	}
}
