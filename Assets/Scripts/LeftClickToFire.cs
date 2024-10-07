using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftClickToFire : MonoBehaviour {


	public GameObject Bullet_Emitter;
	public GameObject Bullet;
	public float Bullet_Forward_Force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate (Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

			Temporary_Bullet_Handler.transform.Rotate (Vector3.left * 90);

			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody> ();

			Temporary_RigidBody.AddForce (transform.forward * Bullet_Forward_Force);
			Destroy (Temporary_Bullet_Handler, 10.0f);
		}
	}
}
