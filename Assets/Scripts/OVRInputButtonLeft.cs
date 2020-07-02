using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class OVRInputButtonLeft : BooleanAction
{
    public OVRInput.Controller controller = OVRInput.Controller.Active;
    public OVRInput.Button button;

    void Update()
    {
        Receive(OVRInput.GetUp(button, controller));
    }
}
