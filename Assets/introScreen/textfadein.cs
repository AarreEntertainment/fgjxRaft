using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textfadein : MonoBehaviour {
	public TextMesh one;
	public TextMesh two;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (one.color.a > 0) {
			one.color = new Color (one.color.r, one.color.g, one.color.b, one.color.a - Time.deltaTime/5);
		}
		if (two.color.a > 0) {
				two.color = new Color (two.color.r, two.color.g, two.color.b, two.color.a - Time.deltaTime/6);
		}
	}
}
