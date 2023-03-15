using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : IInteract
{
    [SerializeField] private bool isOn = false;
    public bool IsOn //Only get for other scripts
    { get { return this.isOn; } }

    [SerializeField] private Material onMaterial;
    [SerializeField] private Material offMaterial;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Door myDoor;
    [SerializeField] private Material myMaterial;
    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        myMaterial = this.GetComponent<Material>();
    }

    public void Toggle(Door door)
    {
        //Change Status
        isOn = !isOn;

        print("IsOn = "+ isOn);

        ToggleColor(isOn);

        //audioSource.Play();

        //If lever is on, door is unlocked 
        door.ToggleLock();
        print("myDoor isLocked = " + myDoor.IsLocked);
    }

    private void ToggleColor(bool isOn)
    {
        if(isOn == true)
        {
            print("Change to on color");
            
        }
        else
        {
            print("Change to off color");

        }
    }

    public override void OnInteract()
    {
        Toggle(myDoor);
        print("Interacted with " + gameObject.name);

    }

    public override void OnFocus()
    {
        print("Looked at " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stopped looking at " + gameObject.name);
    }

}
