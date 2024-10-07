using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightRotation : MonoBehaviour {
	Vector3 rotation = new Vector3 (90,0,0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
		
		gameObject.GetComponent<Transform> ().Rotate (new Vector3 (1,0,0));
		
	}
}
