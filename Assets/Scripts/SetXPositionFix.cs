using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetXPositionFix : MonoBehaviour
{
    public GameObject Target;
    private Quaternion FirstRotation;
    public GameObject Plane;
    private Vector3 PlanePos;
    
    void Start()
    {
        //need FirtsRotation to maintain the rotation of the object through the transformation process
        FirstRotation = Target.transform.rotation;

        //Need the Plane Position for the adjustment of Target position on the plane
        PlanePos = Plane.transform.position;

    }

   
    void Update()
    {
        float x = Plane.transform.position.x;//the Target should maintain its X position to where the Plane is
        float y = Target.transform.position.y;
        float z = Target.transform.position.z;

        var xAdj = Target.transform.localScale.x / 2;//Need this to adjust the position of the target

        if (PlanePos.x>0)//If the Plane is located on the right (positive X) side of the environment
        {
            Target.transform.position = new Vector3(x - xAdj, y, z);
            Target.transform.rotation = FirstRotation;
        }
        else if (PlanePos.x<0)//If the Plane is located on the left (negative X) side of the environment
        {
            Target.transform.position = new Vector3(x + xAdj, y, z);
            Target.transform.rotation = FirstRotation;
        }
    }
}
