using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public AudioClip sound;
	private bool hasPlayed1 = false;
	private bool hasPlayed2 = false;
	private bool hasPlayed3 = false;

	void OnTriggerEnter(Collider other) {
		if (!hasPlayed2) {
			if ((other.gameObject.name == "Player" || other.gameObject.tag == "bullet") && (gameObject.tag == "coins")) {
				AudioSource audio = gameObject.AddComponent<AudioSource > (); 
				audio.PlayOneShot ((AudioClip)Resources.Load ("Power Up Sound Effect")); 
				hasPlayed2 = true; //was orignally on
			}
		}
	}

	void OnCollisionEnter(Collision other) {

		if (!hasPlayed1) {
			if (other.gameObject.name == "Player" && gameObject.tag == "monsters" && gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled == true) {
				//yield WaitForSeconds
				AudioSource audio = gameObject.AddComponent<AudioSource > (); 
				audio.PlayOneShot ((AudioClip)Resources.Load ("scream")); 

				if (gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled == false || gameObject.GetComponentInChildren<MeshRenderer>().enabled == false) {
					hasPlayed1 = true;
				}
			}
		}



		if (!hasPlayed3) {
			if (other.gameObject.tag == "bullet" && gameObject.tag == "monsters") {
				AudioSource audio = gameObject.AddComponent<AudioSource > ();
				audio.PlayOneShot ((AudioClip)Resources.Load ("restartsound")); 
				hasPlayed3 = true; //was originally on
			}
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}