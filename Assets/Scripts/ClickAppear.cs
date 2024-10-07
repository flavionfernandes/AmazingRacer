using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAppear : MonoBehaviour {

	public GameObject gun;

	// Use this for initialization
	void Start () {
		gun.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
			Debug.Log("Pressed click.");	
			gun.gameObject.SetActive (true);
	}
}
