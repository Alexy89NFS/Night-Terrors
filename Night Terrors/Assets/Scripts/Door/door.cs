using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    Interactable interact;
    Animator anim;

    bool isOpen;

    void Start()
    {
        interact = GetComponent<Interactable>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsOpen", isOpen);
    }

    void Update()
    {
        if (interact.interacted)
        {
            isOpen = !isOpen;
            anim.SetBool("IsOpen", isOpen);
            interact.interacted = false;
        }
    }
}