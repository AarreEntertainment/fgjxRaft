using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
	private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
	public GameObject FlashLight;
	public GameObject rope;
	public GameObject Mirror;
	public GameObject Price;
	FlashLight flash;
	[SerializeField]
	private bool FlashLightOnHand = false;
	[SerializeField]
	private bool mirrorOnHand = false;
	private float timer;

    // Use this for initialization
    void Start () {
		//moveTo ();
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		flash = FlashLight.GetComponent<FlashLight> ();
	}

	/*void moveTo(){
		i++;
		if (i >= hotSpots.Length) {
			i = 0;
		}
		transform.position = hotSpots [i].position;
		if (hotSpots [i].gameObject.name.Contains ("Head")) {
			transform.GetChild (0).localPosition = Vector3.zero;
			transform.GetChild (0).localRotation = Quaternion.Euler (new Vector3 (-90, 90, 90));
		} else {
			transform.GetChild (0).localPosition = pivot;
			transform.GetChild (0).localRotation = pivotr;

		}
	}*/

	// Update is called once per frame
	void Update () {
        //device = SteamVR_Controller.Input((int)trackedObject.index);

		if(controller.GetPress(SteamVR_Controller.ButtonMask.Grip) && flash.RescueInc){
			if (Vector3.Distance (transform.position, rope.transform.position) <= 2f) {
				GameObject.Find ("[CameraRig]").transform.parent = rope.transform;
				rope.GetComponentInParent<Helicopter> ().onRide = true;
				Price.SetActive (true);
			}
		}

		if (controller.GetPressUp (SteamVR_Controller.ButtonMask.Grip) && flash.RescueInc) {
			GameObject.Find ("[CameraRig]").transform.parent = null;
		}

		if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip) && Time.time - timer >= 1 && !flash.RescueInc)
		{
			if (flash.RescueInc) {
				if (Vector3.Distance (transform.position, rope.transform.position) <= 2f) {
					GameObject.Find ("[CameraRig]").transform.parent = rope.transform;
				}
			}

			if (Vector3.Distance(transform.position, FlashLight.transform.position) <= 0.5f && !FlashLightOnHand) {
				Debug.Log("nappas");
				FlashLight.transform.parent = transform;
				FlashLight.transform.position = trackedObj.GetComponent<Transform>().position;
				FlashLightOnHand = true;
				FlashLight.transform.localRotation = Quaternion.AngleAxis (180f, new Vector3 (0, 1, 0));
				timer = Time.time;
			}

			if (Vector3.Distance (transform.position, Mirror.transform.position) <= 0.5f && !mirrorOnHand) {
				Mirror.transform.parent = transform;
				Mirror.transform.position = transform.GetComponent<Transform> ().position;
				mirrorOnHand = true;
				timer = Time.time;
			}

			if (mirrorOnHand && Time.time - timer >= 1) {
				Mirror.transform.parent = null;
				mirrorOnHand = false;
			}

			if (FlashLightOnHand && Time.time - timer >= 1) {
				FlashLight.transform.parent = null;
				FlashLightOnHand = false;
			}
            //moveTo();
        }

		if (controller.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			if (FlashLightOnHand) {
				flash.GetHelp ();
				if (flash.RescueInc) {
					FlashLight.transform.parent = null;

				}
			}
		}
       /* if (Input.GetButtonDown ("Fire1")) {
			//moveTo ();
			Debug.Log ("ohjain");
			if (FlashLight.GetComponent<SphereCollider> ().bounds.Contains (controller.transform.pos)) {
				FlashLight.transform.parent = trackedObj.GetComponent<Transform> ();
			}
		}*/
	}


}
