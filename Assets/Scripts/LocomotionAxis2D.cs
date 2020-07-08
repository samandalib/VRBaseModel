using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script for smooth transition with the Left Controller Thumbstick
public class LocomotionAxis2D : MonoBehaviour
{

    //set the speed for Transition
    public float speed;
    //set the gameobject that you want to control, if it is the player, put "PlayAreaAlias" in this field
    [SerializeField]
    private GameObject Target;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))//Boolean: check to see if the Thumbstick on selected controller is touched
        {

            //get the value of the Vector2 of Axis2D from the controller (the value for each is between -1 and 1)
            Vector2 displacement = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            float Xdisplacement = displacement.x;
            float Zdisplacement = displacement.y;

            //set the x and z to the values from Thumbstick
            Target.transform.Translate(new Vector3(Xdisplacement, 0, Zdisplacement) * Time.deltaTime * speed);

        }
    }
}
