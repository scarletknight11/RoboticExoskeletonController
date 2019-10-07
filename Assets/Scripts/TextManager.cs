using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public UIManager uim;
	private Text text;
	public int currentBall = 1;
	const string ballName = "Ball_0";
	public string curBallName;
	const string NextPrefix = "Next Ball : #  ";

	void Start () {
		text = this.GetComponent<Text>();
		currentBall = 1;
		curBallName = ballName + currentBall;
		//Debug.Log (curBallName);
		text.text = NextPrefix + currentBall;		

	}
	public void FindNextBall(){
		if (currentBall == 9) {
			//win
			uim.gameWindow.SetActive (false);
			uim.play = false;
			uim.wWindow.SetActive(true);
		} else {
			currentBall += 1;
			curBallName = ballName + currentBall;
			text.text = NextPrefix + currentBall;
		}
	}
		
	void Update () {
		if (uim.rst) {
			Start ();
			uim.rst = false;
		}
	}
}
