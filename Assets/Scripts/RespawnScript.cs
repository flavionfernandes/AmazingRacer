using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

	public Transform respawnPoint; //Place holder for the spawn point
	public GameControlScript gameControlScript;

	// Triggers when the player enters the water
	void OnTriggerEnter(Collider other)
	{
		// Moves the player to the spawn point
		if (other.gameObject.tag == "Player" && gameObject.name == "WaterDetector") {
			other.gameObject.transform.position = respawnPoint.position;
		} else if (other.gameObject.tag == "Player" && gameObject.name == "LavaDetector") {
			gameControlScript.FinishedGame ();
		} else if (other.gameObject.tag != "Player") {
			Destroy (other.gameObject);
		}

		/////try and figure out how to reset the rotation when respawned below
		//other.gameObject.transform.rotation = Quaternion.Euler (0,-187,0);
		//187
	}
}
