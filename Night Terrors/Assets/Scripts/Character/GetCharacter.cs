using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCharacter : MonoBehaviour {

	public static GameObject character;
	public static Camera cam;

	void Awake() {
		character = gameObject;
		cam = GetComponentInChildren<Camera> ();
	}

	public static void MovePlayerToPosition(Transform position, Transform parent){

		if (parent != null) {
			character.transform.SetParent (parent, false);
		}
		character.transform.position = position.position;
		character.transform.rotation = position.rotation;
	}
		
}
