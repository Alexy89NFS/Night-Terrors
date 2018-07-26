using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

    public float distance = 5f;
    public Image crossHairs;
    GameObject cam;

    void Start()
    {
        cam = gameObject;
    }

    void Update()
    {
        RaycastHit hit;
        if (cam.activeInHierarchy)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
            {
                if (hit.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interact = hit.collider.GetComponent<Interactable>();
                    if (interact.isInteractable == true)
                    {
                        ChangeColor(Color.green);
                        if (Input.GetButtonDown("Interact"))
                        {
                            interact.interacted = true;
                        }
                    }
                    else
                    {
                        ChangeColor(Color.white);
                    }
                }
                else
                {
                    ChangeColor(Color.white);
                }
            }
            else
            {
                ChangeColor(Color.white);
            }
        }
    }

    void ChangeColor(Color color)
    {
        crossHairs.color = color;
    }
}
