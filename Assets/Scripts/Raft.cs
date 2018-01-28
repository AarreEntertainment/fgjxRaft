using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour {

	public float speed = 10f;
	int way = 1;
	// Use this for initialization
	void Start () {
		//StartCoroutine_Auto (RotateRaft());
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.z >= 25f) {
			way = -way;
		} else if(transform.rotation.eulerAngles.z <= -25f) {
			way = -way;
		}
		transform.RotateAround(transform.position, transform.forward, Mathf.Sign( way)* Mathf.Sin(Time.deltaTime * 10f));
		//transform.rotation = new Quaternion (Mathf.Sin () * transform.rotation.x,transform.rotation.y,
			//Mathf.Cos (Time.deltaTime) +  transform.rotation.z, transform.rotation.w);
	}


}
