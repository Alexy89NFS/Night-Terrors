using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMoving : MonoBehaviour {

    public GameObject spriteCharacter;
    public bool moving = false;

    Interactable interact;

	public GameObject gameCam;
	Camera playerCam;
	GameObject character;
	bool hasActivatedGame = false;

	Transform playerCamPosition;
	Transform gameCamPosition;

    void Start()
    {
		hasActivatedGame = false;
		moving = false;
        interact = GetComponent<Interactable>();
		gameCam.GetComponent<Camera> ().enabled = false;

		character = GetCharacter.character;
		playerCam = GetCharacter.cam;

		gameCamPosition = gameCam.transform;
    }

    void Update()
    {
		if (interact.interacted)
        {
			moving = !moving;
			interact.interacted = false;
        }

		if (moving) {
			if (!hasActivatedGame) {   //Run Stuff Once
				character.GetComponent<CharacterMovement> ().enabled = false;
				character.GetComponent<Collider> ().enabled = false;

				playerCam.transform.SetParent (gameCam.transform);

				playerCamPosition = playerCam.transform;
				GetCharacter.MovePlayerToPosition (gameCam.transform, null);

				hasActivatedGame = true;
			}

			Vector3 moveDirection = new Vector3 (0f, Input.GetAxis ("Vertical") * Time.deltaTime, Input.GetAxis ("Horizontal") * Time.deltaTime);

			spriteCharacter.transform.position += moveDirection;
		} 
		else if (!moving)
		{
			if (hasActivatedGame)
			{
				playerCam.transform.SetParent (character.transform);

				playerCam.transform.position = playerCamPosition.position;
				playerCam.transform.rotation = playerCamPosition.rotation;

				character.GetComponent<CharacterMovement> ().enabled = true;
				hasActivatedGame = false;
			}
		}
    }
}