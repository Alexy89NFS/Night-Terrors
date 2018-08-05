using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class alarmClock : MonoBehaviour {

	public float time;
	public float minsPerSec = 1;

	public float startTime = 3;
	public float finishTime = 6;

	AudioSource audioSource;
	public bool timeUp = false;

	float finishfloatTime;

	TextMeshPro text;

	void Start() {
		time = startTime * 3600;

		finishfloatTime = finishTime * 3600;

		audioSource = GetComponent<AudioSource> ();
		text = GetComponentInChildren<TextMeshPro> ();
	}

	void Update() {
		if (!timeUp) {
			time += Time.deltaTime * ((1 / minsPerSec) * 60);
		}

		TimeSpan currentTime = TimeSpan.FromSeconds(time);
		string[] tempTime = currentTime.ToString ().Split (":" [0]);
		text.text = tempTime [0] + ":" + tempTime [1];

		if (time >= finishfloatTime && !timeUp) {
			if (audioSource.clip != null) {
                audioSource.Play ();
			}
			Debug.Log ("Time Up");
			timeUp = true;
		}
	}
}
