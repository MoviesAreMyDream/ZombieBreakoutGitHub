using UnityEngine;
using System.Collections;
using Windows.Kinect;
//This script handles movement of an object by detecting the differences between 2 joints detected by the Kinect
public class KinectJointPosition : MonoBehaviour {

    public JointType _jointTypeA; //left body joint
    public JointType _jointTypeB; //right body joint
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    
	void Update () {

        CharacterController controller = GetComponent<CharacterController>();

        if (_bodySourceManager == null)
        {
            return;
        }

        _bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();
        if (_bodyManager == null)
        {
            return;
        }

        Body[] data = _bodyManager.GetData();
        if (data == null)
        {
            return;
        }

        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                var posA = body.Joints[_jointTypeA].Position; //position of left joint
                var posB = body.Joints[_jointTypeB].Position; //position of right joint
                var footDistance = (posA.Z - posB.Z)*100; //difference between the two joints
                //Debug.Log("Foot Distance " + footDistance);

                    if (footDistance >= 24)
                    {
                        moveDirection = transform.TransformDirection(Vector3.back);
                        moveDirection *= speed;
                        controller.SimpleMove(moveDirection * speed);
                    }
                    if (footDistance <= -5)
                    {
                        moveDirection = transform.TransformDirection(Vector3.forward);
                        moveDirection *= speed;
                        controller.SimpleMove(moveDirection * speed);
                    }
                    if (footDistance > -5)
                    {
                        if(footDistance < 24)
                        {
                            controller.SimpleMove(moveDirection * 0);
                        }
                    }
                break;
            }
        }
	}
}
