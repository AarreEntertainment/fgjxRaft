using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToCamera : MonoBehaviour {
	private Transform cameraTransform;
	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.transform.position + (Vector3.down + new Vector3(0, -0.2f, 0));
		transform.rotation = Camera.main.transform.rotation;
	}

	IEnumerator moveToHead(){
		yield return new WaitForSeconds (0.5f);
		cameraTransform = Camera.main.transform;

	}
}
