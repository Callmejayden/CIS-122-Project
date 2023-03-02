using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteract : IInteract
{
    public override void OnInteract()
    {
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
