using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetYPositionFix : MonoBehaviour
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
        float x = Target.transform.position.x;
        float y = Plane.transform.position.y;//the Target should maintain its Y position to where the Plane is
        float z = Target.transform.position.z;

        var yAdj = Target.transform.localScale.y / 2;//Need this to adjust the position of the target

        if (PlanePos.y > 0)//If the Plane is located on the top (positive Y) side of the environment
        {
            Target.transform.position = new Vector3(x, y-yAdj, z);
            Target.transform.rotation = FirstRotation;
        }
        else if (PlanePos.y <= 0)//If the Plane is located on the down (negative y) side of the environment
        {
            Target.transform.position = new Vector3(x, y+yAdj, z);
            Target.transform.rotation = FirstRotation;
        }
    }
}
