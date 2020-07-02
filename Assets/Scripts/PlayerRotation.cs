using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{


    //set the gameobject that you want to control, if it is the player, put "PlayAreaAlias" in this field
    [SerializeField]
    private GameObject Target;

    [SerializeField]
    private int _rotationSpeed = 30;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))//Boolean: check to see if the Thumbstick on selected controller is touched
        {
            //get the value of the Vector2 of Axis2D from the controller (the value for each is between -1 and 1)
            Vector2 displacement = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            float Xdisplacement = displacement.x;//we can only use one value for rotation

            //To make it more clear which axis we are going to rotate around
            float YRotation = Xdisplacement;
            
            //RotateAround(the point where we want the rotation happens in, the Axis we want the rotation happen around, the speed or degree of rotation)
            Target.transform.RotateAround(Target.transform.position, new Vector3(0, YRotation, 0) , _rotationSpeed * Time.deltaTime);
        }
        



    }
}
