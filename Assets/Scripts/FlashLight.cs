using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class FlashLight : MonoBehaviour {

	private bool AnyHelper = false;
	private Transform helperLocation;
	private Light lightSource;
	public float chance = 10;
	public bool RescueInc;
	public GameObject helicopter;
	public GameObject LightRay;
	public DayTime DayTime;

	public Material[] flashableMaterials;
	// Use this for initialization
	void Start () {
		lightSource = GetComponentInChildren<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (AnyHelper) {

		}
	}

	public void GetHelp(){
		RaycastHit hit;
		//if (!DayTime.IsDay) {
			if (Physics.Raycast (transform.position, transform.rotation.eulerAngles, out hit)) {
				//if(hit.collider.gameObject.tag.Contains("Plane")){
				StartCoroutine(FlashTarget());
				Debug.Log (hit.collider.gameObject.name);
				StartCoroutine (flash ());
				float rand = Random.Range (0, 100);
				if (rand <= chance) {
					Debug.Log ("YOU ARE WIINER");
					RescueInc = true;
					helicopter.SetActive (true);
				}
				//}
			}
		//}
	}

	IEnumerator FlashTarget(){
		
		foreach (Material curMat in flashableMaterials) {
			//Debug.Log (curMat.name);
			curMat.EnableKeyword ("_EMISSION");
			//curMat.SetFloat ("_EMISSION", 1);
			curMat.SetColor ("_EmissionColor", Color.white);
		}

		yield return new WaitForSeconds (1);
		foreach (Material curMat in flashableMaterials) {
			curMat.DisableKeyword ("_EMISSION");
			//curMat.SetFloat ("_EMISSION", 0);
		}
	}

	public void enableLight(){
		lightSource.enabled = !lightSource.enabled;
		LightRay.SetActive (lightSource.enabled);
	}

	IEnumerator flash(){
		enableLight ();
		yield return new WaitForSeconds (0.2f);
		enableLight ();
	}

	public void SetHelperActive(Transform helperTransform){
		AnyHelper = true;
		helperLocation = helperTransform;
	}
}
