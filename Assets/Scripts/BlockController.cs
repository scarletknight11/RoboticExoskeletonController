using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	public TextManager textm;
	public UIManager uim;

	void Start () {
		
	}
	

	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "CueBall") {
			//Lose
			//Debug.Log ("C!");
			Debug.Log("Cue Ball");
			collision.gameObject.SetActive (false);

			uim.gameWindow.SetActive (false);
			uim.play = false;
			uim.lWindow.SetActive (true);

		} else if (collision.gameObject.tag == "Ball") {
			//Debug.Log (collision.gameObject.name);
			collision.gameObject.SetActive (false);

			//check num
			if (collision.gameObject.name == textm.curBallName) {
				textm.FindNextBall ();			
			} else {
				//lose
				Debug.Log("Wrong Ball");
				uim.gameWindow.SetActive (false);
				uim.play = false;
				uim.lWindow.SetActive (true);
			}
		} 

	}

}
