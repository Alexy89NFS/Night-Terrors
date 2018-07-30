using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCharacter : MonoBehaviour {

	public static GameObject character;

	void Awake() {
		character = gameObject;
	}
		
}
