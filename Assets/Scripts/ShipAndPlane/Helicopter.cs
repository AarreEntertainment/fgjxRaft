using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	public bool onRide;
	public Transform playerLocation;
	public float Speed = 20f;
	// Use this for initialization
	void Start () {
		//StartCoroutine (moveAfter ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!onRide) {
			transform.position = transform.position + transform.forward * Time.deltaTime * Speed;

			if (Vector3.Distance (transform.position, playerLocation.position) >= 100f) {
				transform.RotateAround (transform.position, new Vector3 (0, 1, 0), 180);
			}

		}
		if (onRide) {
			//transform.position = transform.position + new Vector3(0, 1, 1)* Time.deltaTime * 5f;
			transform.position = transform.position + (transform.forward +  new Vector3(0, 0.15f, 1.0f)) * Time.deltaTime * Speed / 2;

		}
	}
}
