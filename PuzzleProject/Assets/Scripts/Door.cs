using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : IInteract
{
    private bool isOpen = false;
    private bool canBeInteractedWith = true;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public override void OnInteract()
    {
        print("Interacted with " + gameObject.name);
        if (canBeInteractedWith)
        {
            //toggles from true to false
            isOpen =! isOpen;

            print("Open " + gameObject.name);

            Vector3 doorTransformDirection = transform.TransformDirection(Vector3.forward);

            print("Door Transform Direction Set");

            Vector3 playerTransformDirection = FirstPersonControll.instance.transform.position - transform.position;

            print("Player Transform Direction Set");

            float dot = Vector3.Dot(doorTransformDirection, playerTransformDirection);

            print("dot is" + dot);

            anim.SetFloat("dot",dot);
            anim.SetBool("isOpen", isOpen);

        }
    }
    
    public override void OnFocus()
    {
    }

    public override void OnLoseFocus()
    {
    }


}
