using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShipOrPlane : MonoBehaviour {
	
	public GameObject SpawnModel;
	public Transform SpawnPoint, endpoint;
	public float spawnTime = 3f;
	public float LifeTime = 30f;
	private float startTime;
	private bool spawned = false;
	public bool plane;
	private GameObject obj;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (spawned) {
			if (Time.time - startTime >= LifeTime) {
				spawned = false;
				Destroy (obj);
			}
		}

		if ((Time.time - startTime) >= spawnTime && !spawned) {
			Vector3 dir = (endpoint.position - SpawnPoint.position).normalized;
			obj = Instantiate (SpawnModel, SpawnPoint.position ,new Quaternion(dir.x, dir.y, dir.z, 1f)) as GameObject;
			obj.GetComponent<MoveObject> ().direction = dir;
			startTime = Time.time;
			spawned = true;
			if (plane) {
				obj.transform.RotateAround (transform.position, new Vector3 (0, 0, 1), -90);
			}
		}
	}

	/*public void ResetTimer(){
		startTime = Time.time;
		spawned = false;
	}*/

}
