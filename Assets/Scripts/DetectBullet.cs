using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBullet : MonoBehaviour {

	public GameObject Bridge;


	void OnTriggerEnter(Collider other) {
		Debug.Log("test is working");

		if (other.gameObject.tag == "bullet") {
			Bridge.GetComponent<Rigidbody> ().useGravity = true;
			Bridge.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
