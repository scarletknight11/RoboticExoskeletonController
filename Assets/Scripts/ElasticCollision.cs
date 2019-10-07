using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticCollision : MonoBehaviour {
	Rigidbody rb;
	private Vector3 m_preVelocity = Vector3.zero;//上一帧速度

	void Start(){
		rb = this.GetComponent<Rigidbody> ();

	}
	void Update(){
		m_preVelocity = rb.velocity;
	}
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Side")
		{
			ContactPoint contactPoint = collision.contacts[0];
			Vector3 newDir = Vector3.zero;
			Vector3 curDir = transform.TransformDirection(Vector3.forward);
			newDir = Vector3.Reflect(curDir, contactPoint.normal);
			Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
			transform.rotation = rotation;
			rb.velocity = newDir.normalized * m_preVelocity.x / m_preVelocity.normalized.x;
		}
	}
}
