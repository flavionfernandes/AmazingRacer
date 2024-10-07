using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour {
	//public int scoreValue;
	public Transform respawnPoint; //Place holder for the spawn point
	private GameControlScript gameController;

	void OnTriggerEnter(Collider other) {
		if ((other.gameObject.name == "Player" || other.gameObject.tag == "bullet") && (gameObject.tag == "coins" && gameObject.GetComponent<Renderer> ().enabled == true)) {
			gameController.AddScore (1);
			//Destroy (gameObject);
			//gameObject.SetActive(false);
			GetComponent<Renderer> ().enabled = false;
		}
	}

	void OnCollisionEnter(Collision other) {



		if ((other.gameObject.name == "Player") && (gameObject.tag == "monsters" && gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().enabled == true)) {
			other.gameObject.transform.position = respawnPoint.position;

		}
	



		if ((other.gameObject.tag == "bullet") && (gameObject.tag == "monsters" && gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled == true)) {
			gameController.AddScore (2);
			//Destroy (gameObject);
			//gameObject.SetActive(false);
			GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;

			SkinnedMeshRenderer[] rs = GetComponentsInChildren<SkinnedMeshRenderer> ();
			foreach(SkinnedMeshRenderer r in rs) {
				r.enabled = false;
			}
		}


	}

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("controller");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameControlScript> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
