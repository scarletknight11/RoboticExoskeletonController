using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour {

	public PoleController poleCtrl;
	public UIManager uim;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Pole") {
			//Debug.Log ("P");
			poleCtrl.Reset ();
		}
		else if (other.gameObject.tag == "Ball" || other.gameObject.tag == "CueBall") {
			//lose
			Debug.Log("Boundary");
			uim.gameWindow.SetActive (false);
			uim.play = false;
			uim.lWindow.SetActive (true);
		}
	}

}
