using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackForth : MonoBehaviour {
	

	public int x1;
	public int y1;
	public int z1;
	public int x2;
	public int y2;
	public int z2;


	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 Vector3 pos1 = new Vector3(x1,y1,z1); //143.35,0.48,86.66
		Vector3 pos2 = new Vector3(x2,y2,z2); //139.51,0.48,81.09
		transform.position=Vector3.Lerp (pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
	}
}
