using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour {

    Animator anim;
    Interactable interact;

    bool open = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        interact = GetComponent<Interactable>();
        anim.SetBool("isOpen", open);
    }

    void Update()
    {
        if (interact.interacted == true)
        {
            open = !open;
            anim.SetBool("isOpen", open);
            interact.interacted = false;
        }
    }
}
