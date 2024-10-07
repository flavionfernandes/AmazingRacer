using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullets : MonoBehaviour {

	public GameObject ball;
	public static int bulletCount;
	public float speed = 200; //change it according to the desired speed

	void Update(){
		if (Input.GetButtonUp ("Fire1")) {
			if (bulletCount > 0) {
				GameObject newBall = Instantiate (ball, transform.position, transform.rotation);
				newBall.GetComponent<Rigidbody> ().velocity = transform.forward * speed;

				//Destroys the ball after one second
				Destroy (newBall, 1f);
				bulletCount -= 1;
			}
		}
	}

}
