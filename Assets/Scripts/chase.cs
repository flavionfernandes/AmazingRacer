using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {

	public Transform player;
	public static int lookDistance =10;
	public static int walkDistance =5;
	private Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Vector3.Distance (player.position, this.transform.position) < lookDistance) {
			
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0; //prevents monster from falling over when coming close to player

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 20f * Time.deltaTime);

			anim.SetBool ("isIdle", true);
			if (direction.magnitude < walkDistance) {
				
				this.transform.Translate (0, 0, 0.05f);
				anim.SetBool ("isAttacking", true);
			} else {
				anim.SetBool ("isAttacking",false);
				anim.SetBool ("isIdle",true);
			}


		}
	}
}
