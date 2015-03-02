using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public GUIText textTime;


	public int playtime = 0;
	private int seconds = 0;
	private int minutes = 0;
	private int hours = 0;


	// Use this for initialization
	void Start () {
		StartCoroutine ("Playtimer");
	}

	private IEnumerator Playtimer()
	{
		while (true) {
			//if(gateNum ==0) break;
			yield return new WaitForSeconds(1);
			playtime+=1;
			seconds = (playtime%60);
			minutes = (playtime/60)%60;
			hours = (playtime/3600)%24;
			if(mainMenu.numOfGates ==0 && mainMenu.levelLoaded) break;
		}
	}

	
	// Update is called once per frame
	void OnGUI () {
		textTime.text = (hours + ":" + minutes + ":" + seconds);
	}
}
