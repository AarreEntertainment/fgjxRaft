using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour {
	Light sun;

	public int lengOfDayInSeconds = 120;
	private float progress = 0f;

	private bool isDay = true;
	public bool IsDay{ get { return isDay; } }

	private void Start(){
		progress = Random.Range (0, 190);
	}

	void Update(){
		progress = (progress + (360f / (float)lengOfDayInSeconds) * Time.deltaTime) % 360f;
		isDay = progress < 190f && progress > -190f;

		transform.eulerAngles = new Vector3 (progress, -30f, 0);
	}
}
