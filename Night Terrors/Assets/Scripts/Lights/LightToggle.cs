using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour {

	public Light lightSource;
	public float maxTimeAllowed = 20f;

	public float minIntensity = 30f;
	public float maxIntensity = 150f;

	public Color lowLight;
	public Color highLight;

	float intensityDifference;

	float colorRDifference;
	float colorGDifference;
	float colorBDifference;

	Animator anim;
	Interactable interact;

	bool isOpen = false;
	bool overHeated = false;

	float timer;

	void Start() {
		anim = GetComponent<Animator> ();
		UpdateSwitch (isOpen);

		intensityDifference = (maxIntensity - minIntensity) / maxTimeAllowed;

		colorRDifference = (highLight.r - lowLight.r) / maxTimeAllowed;
		colorGDifference = (highLight.g - lowLight.g) / maxTimeAllowed;
		colorBDifference = (highLight.b - lowLight.b) / maxTimeAllowed;

		interact = GetComponent<Interactable> ();
	}

	void Update() {
		if (interact.interacted) {
			isOpen = !isOpen;
			UpdateSwitch (isOpen);
			interact.interacted = false;
		}

		if (lightSource.enabled == true && !overHeated) {
			timer += Time.deltaTime;
		} else {
			if (timer > 0) {
				timer -= Time.deltaTime;
			}
		}

		if (overHeated && timer <= 0) {
			interact.isInteractable = true;
			overHeated = false;
		}

		if (timer >= maxTimeAllowed) {
			UpdateSwitch (false);
			interact.isInteractable = false;
			isOpen = false;
			overHeated = true;
		}
			
		float intensity = minIntensity + (timer - 1) * intensityDifference;
		lightSource.intensity = intensity;

		float colorR = lowLight.r + (timer - 1) * colorRDifference;
		float colorG = lowLight.g + (timer - 1) * colorGDifference;
		float colorB = lowLight.b + (timer - 1) * colorBDifference;

		lightSource.color = new Color (colorR, colorG, colorB, 255);
	}

	void UpdateSwitch(bool toggle) {
		if (!overHeated) {
			anim.SetBool ("IsOpen", toggle);
			lightSource.enabled = toggle;
		}
	}
}