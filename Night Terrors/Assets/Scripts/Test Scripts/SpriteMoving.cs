using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMoving : MonoBehaviour {

    public GameObject spriteCharacter;
    public bool moving = false;

    Interactable interact;

	public GameObject gameCam;
	bool hasActivatedGame;

    void Start()
    {
        interact = GetComponent<Interactable>();
		gameCam.SetActive (false);
    }

    void Update()
    {
		if (interact.interacted)
        {
			moving = !moving;
			interact.interacted = false;
        }

		if (moving) {
			if (!hasActivatedGame) {
				gameCam.SetActive (true);
				GetCharacter.character.GetComponentInChildren<Camera> ().gameObject.SetActive (false);
				hasActivatedGame = true;
			}

			GetCharacter.character.GetComponent<CharacterMovement> ().enabled = false;

			Vector3 moveDirection = new Vector3 (0f, Input.GetAxis ("Vertical") * Time.deltaTime, Input.GetAxis ("Horizontal") * Time.deltaTime);

			spriteCharacter.transform.position += moveDirection;

			if (Input.GetButtonDown ("Interact")) {
				moving = false;
			}
		} 
		else if (!moving)
		{
			if (hasActivatedGame)
			{
				gameCam.SetActive (false);
				GetCharacter.character.GetComponent<CharacterMovement> ().enabled = true;
				GetCharacter.character.GetComponentInChildren<Camera> ().gameObject.SetActive (true);
				hasActivatedGame = false;
			}
		}
    }
}
