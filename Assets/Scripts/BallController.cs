using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public UIManager uim;
	public GameObject[] Balls;
	float stPointX = 0.0f;
	float stPointY = 1.86f;
	float stPointZ = -0.86f;
	float offsetX = 0.36f;
	float offsetZ = 0.385f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Balls.Length; i++) {
			Balls [i].SetActive (true);
			Balls [i].GetComponent<Rigidbody> ().velocity = Vector3.zero;
			Balls [i].GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		}
		Balls [0].transform.position = new Vector3 (Random.Range(-2.25f,2.25f), stPointY, stPointZ * 4);
		Balls [1].transform.position = new Vector3 (stPointX, stPointY, stPointZ);

		Balls [2].transform.position = new Vector3 (stPointX+offsetX,stPointY,stPointZ+offsetZ);
		Balls [3].transform.position = new Vector3 (stPointX-offsetX,stPointY,stPointZ+offsetZ);

		Balls [4].transform.position = new Vector3 (stPointX+offsetX*2,stPointY,stPointZ+offsetZ*2);
		Balls [5].transform.position = new Vector3 (stPointX-offsetX*2,stPointY,stPointZ+offsetZ*2);
		Balls [9].transform.position = new Vector3 (stPointX,stPointY,stPointZ+offsetZ*2);

		Balls [6].transform.position = new Vector3 (stPointX+offsetX,stPointY,stPointZ+offsetZ*3);
		Balls [7].transform.position = new Vector3 (stPointX-offsetX,stPointY,stPointZ+offsetZ*3);

		Balls [8].transform.position = new Vector3 (stPointX,stPointY,stPointZ+offsetZ*4);
	}

	void Update () {
		if (uim.rst) {
			Start ();
			uim.rst = false;
		}
	}
}
