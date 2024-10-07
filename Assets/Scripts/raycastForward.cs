using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastForward : MonoBehaviour {

	public Texture defaultTexture;
	public Texture wellDoneTexture;
	public Texture instructionTexture;

	// Update is called once per frame
	void Update () {
		
		// Debug Raycast in the editor - SO WE CAN SEE IT!
		RaycastHit hit;
		float theDistance;
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 10;
		Debug.DrawRay (transform.position,forward,Color.green);

		if(Physics.Raycast(transform.position,(forward), out hit)){
			theDistance = hit.distance;
			print (theDistance + " " + hit.collider.gameObject.name);
		}

		if (hit.collider.gameObject.name == "Instruct") {
			GameObject.FindGameObjectWithTag("instructions").GetComponent<Renderer> ().material.mainTexture = instructionTexture;
		} else if (hit.collider.gameObject.name == "Sphere(Clone)") {
			GameObject.FindGameObjectWithTag("instructions").GetComponent<Renderer> ().material.mainTexture = wellDoneTexture;	
		} else {
			GameObject.FindGameObjectWithTag("instructions").GetComponent<Renderer> ().material.mainTexture = defaultTexture;
		}
	}
}
