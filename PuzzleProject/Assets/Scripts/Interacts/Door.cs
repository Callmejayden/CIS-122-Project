using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : IInteract
{

    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool canBeInteractedWith = true;
    private Animator anim;
    [SerializeField] private bool isLocked = true;
    public bool IsLocked
    {
        get { return this.isLocked; }
        set { this.isLocked = value; }
    }


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleLock()
    {
        isLocked = !isLocked;
    }

    public void DoorInteract()
    {
        //toggles from true to false
        isOpen = !isOpen;

        print("Open " + gameObject.name);

        Vector3 doorTransformDirection = transform.TransformDirection(Vector3.forward);

        print("Door Transform Direction Set");

        Vector3 playerTransformDirection = FirstPersonControll.instance.transform.position - transform.position;

        print("Player Transform Direction Set");

        float dot = Vector3.Dot(doorTransformDirection, playerTransformDirection);

        print("dot is" + dot);

        anim.SetFloat("dot", dot);
        anim.SetBool("isOpen", isOpen);

    }

    public override void OnInteract()
    {
        //if door is unlocked
        if (IsLocked == false)
        {
            print("Interacted with " + gameObject.name);
            //if not currently in animation
            if (canBeInteractedWith)
            {
                DoorInteract();
            }
        }
        else
        {
            print("Door is locked");
        }
    }
    
    public override void OnFocus()
    {
    }

    public override void OnLoseFocus()
    {
    }


}
