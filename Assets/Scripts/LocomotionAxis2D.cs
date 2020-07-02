using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class LocomotionAxis2D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody Player;
    public float speed;
    private Vector2 _controller;
    
    public enum ControllerChoice
    {
        Left_Thumbstick,
        Right_Thumbstick
    }
    public ControllerChoice currentChoice;
    // Start is called before the first frame update
    void Start()
    {
        switch(currentChoice)
        {
            case ControllerChoice.Left_Thumbstick:
                _controller = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
                break;
            case ControllerChoice.Right_Thumbstick:
                _controller = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float fixedY = Player.transform.position.y;


        Player.transform.position += (transform.right * _controller.x + transform.forward * _controller.y) * Time.deltaTime * speed;
        Player.transform.position = new Vector3(Player.transform.position.x, fixedY, Player.transform.position.z);
    }
}
