using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleController : MonoBehaviour {

	public UIManager uim;
	public GameObject cueBall;
	public float speed = 20f;
	public Transform m_target;
	public float passTime = 0.0f;

	Vector3 target;
	Vector3 movement;
	Vector3 startPos;

	private Rigidbody plRigidbody;

	bool down = false;
	bool up = false;
	bool buff = false;
	bool available = false;

	float startTime;
	float endTime;
	float buffStartTime;

	float pushDistance;
	float pullSpeed;
	float newPullSpeed;


	void Awake(){
		plRigidbody = this.GetComponent<Rigidbody> ();
		startPos = new Vector3 (0,2.14f,-7.8f);
		this.transform.position = startPos;
		this.transform.Rotate(90, 0, 0);
		this.transform.LookAt(m_target);
		down = false;
		up = false;
		buff = false;
		available = true;
		passTime = 0.0f;
	}

	void FixedUpdate(){
		if (uim.rst) {
			Awake ();
			uim.rst = false;
		}
		if (uim.play) {
			if (Input.GetMouseButtonDown (0)) {
				if (available) {
					available = false;
					//Charge
					//Debug.Log ("Down");
					down = true;
					target = cueBall.transform.position;
					LooknRotate ();
					startTime = Time.time;
				}
				
			} else if (down == true && !available) {
				//Debug.Log ("Down_T");
				passTime = Time.time - startTime;
				if (passTime < 1.0f) {
					plRigidbody.AddForce ((target - this.transform.position) * speed * (-1));
					if (Input.GetMouseButtonUp (0)) {
						//Strike
						down = false;
						up = true;
					}

				} else {
					plRigidbody.AddForce ((target - this.transform.position) * speed * (-1));
					down = false;
					up = true;
				}
				
			} else if (up == true && !available) {
				//Debug.Log ("UP_T");
				endTime = Time.time;
				plRigidbody.velocity = (cueBall.transform.position - this.transform.position) * (endTime - startTime) * speed;


			} else if (buff == true && !available) {
				//Debug.Log ("BUF_T");
				Reset ();
				if ((Time.time - buffStartTime) > 0.5f) {
					//check if the cue ball has stopped
					if (Vector3.Distance (movement, cueBall.transform.position) <= 0.01f) {
						down = false;
						up = false;
						buff = false;
						available = true;
						Reset ();

					} else {
						movement = cueBall.transform.position;
						buffStartTime = Time.time;
					}
				}

			} else if (available) {	
				Move ();
			}
		}


//		if(Input.GetKeyDown(KeyCode.Escape)){
//			
//			Reset();
//
//		}

	}

	void Move(){
		LooknRotate();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray , out hit))
		{
			//Vector3 mousePosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
			Vector3 playerToMouse = hit.point - transform.position;
			playerToMouse.y = 0f;
			Vector3 mov = this.transform.position + playerToMouse;
			if (mov.x < 10 && mov.x > -10 && mov.y > -10 && mov.y < 10 && mov.z > -13 && mov.z < 13) {
				if (Vector3.Distance (mov, cueBall.transform.position) > 3.0f) {
					plRigidbody.MovePosition (this.transform.position + playerToMouse);
				}
			} else {
				Reset ();
			}
			//plRigidbody.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
			//hit.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		}
			
	}

	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "CueBall")
		{
			up = false;
			buff = true;
			movement = cueBall.transform.position;
			buffStartTime = Time.time;

		}

	}

	public void Reset(){
		passTime = 0.0f;
		this.transform.position = startPos;
		LooknRotate();
	}

	void LooknRotate(){
		this.transform.LookAt(m_target);
		this.transform.Rotate(90, 0, 0);
	}

}
