using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handController : MonoBehaviour {
	public Transform leftHandParent;
	public Transform rightHandParent;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
			}
	void OnAnimatorIK(){
		anim.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1);
		anim.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
		anim.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1);
		anim.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
		anim.SetIKPosition (AvatarIKGoal.LeftHand, leftHandParent.position);
		anim.SetIKPosition (AvatarIKGoal.RightHand, rightHandParent.position);
		anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandParent.rotation);
		anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandParent.rotation);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
