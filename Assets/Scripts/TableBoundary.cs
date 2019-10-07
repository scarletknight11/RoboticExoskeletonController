using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBoundary : MonoBehaviour {

	public UIManager uim;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Ball" || other.gameObject.tag == "CueBall") {
			Debug.Log("Table BOundary");
			//lose
			uim.gameWindow.SetActive (false);
			uim.play = false;
			uim.lWindow.SetActive (true);
		}
	}
}
