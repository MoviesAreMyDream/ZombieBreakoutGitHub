using UnityEngine;
using System.Collections;
using Windows.Kinect;
//This script handles movement of an object by detecting the differences between 2 joints detected by the Kinect
public class KinectJointPosition : MonoBehaviour {

    public GameObject _bodySourceManager;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    private BodySourceManager _bodyManager;
    private JointType _jointTypeA = JointType.AnkleLeft; 
    private JointType _jointTypeB = JointType.AnkleRight; 
    private Vector3 moveDirection = Vector3.zero;

    private JointType _jointTypeC = JointType.SpineShoulder;
    private JointType _jointTypeD = JointType.SpineBase;

    //private JointType _jointTypeE = JointType.ShoulderRight;
    //private JointType _jointTypeF = JointType.ShoulderLeft;

    void Start()
    {
        _bodySourceManager = GameObject.Find("BodyManager");

    }


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
                //var posA = body.Joints[_jointTypeA].Position; //position of left joint
                //var posB = body.Joints[_jointTypeB].Position; //position of right joint
                //var footDistance = (posA.Z - posB.Z) * 100; //difference between the two joints

                var posC = body.Joints[_jointTypeC].Position;
                var posD = body.Joints[_jointTypeD].Position;
                var spineDistance = (posC.Z - posD.Z) * 100;

                //var posE = body.Joints[_jointTypeE].Position;
                //var posF = body.Joints[_jointTypeF].Position;
                var shoulderDistance = (posC.X - posD.X) * 100;

                //Debug.Log("Foot Distance " + footDistance);

                //if (footDistance >= 20)
                //    {
                //        moveDirection = transform.TransformDirection(Vector3.back);
                //        moveDirection *= speed;
                //        controller.SimpleMove(moveDirection * speed);
                //    }
                //    if (footDistance <= -20)
                //    {
                //        moveDirection = transform.TransformDirection(Vector3.forward);
                //        moveDirection *= speed;
                //        controller.SimpleMove(moveDirection * speed);
                //    }
                //    if (footDistance > -10)
                //    {
                //        if(footDistance < 24)
                //        {
                //            controller.SimpleMove(moveDirection * 0);
                //        }
                //    }
                //break;

                //if (spineDistance >= 20)//use spine to go backward
                //{
                //    moveDirection = transform.TransformDirection(Vector3.back);
                //    moveDirection *= speed;
                //    controller.SimpleMove(moveDirection * speed);
                //    Debug.Log(spineDistance);
                //}
                if (spineDistance <= -30)
                {
                    moveDirection = transform.TransformDirection(Vector3.forward);
                    moveDirection *= speed;
                    controller.SimpleMove(moveDirection * speed);
                    Debug.Log(spineDistance);
                }
                //if (spineDistance > -10)
                //{
                //    if (spineDistance < 24)
                //    {
                //        controller.SimpleMove(moveDirection * 0);
                //    }
                //}

                if (shoulderDistance >= 10)
                {
                    moveDirection = transform.TransformDirection(Vector3.right);
                    moveDirection *= speed;
                    controller.SimpleMove(moveDirection * speed);
                }
                if (shoulderDistance <= -10)
                {
                    moveDirection = transform.TransformDirection(Vector3.left);
                    moveDirection *= speed;
                    controller.SimpleMove(moveDirection * speed);
                }
                //if (shoulderDistance > -10)
                //{
                //    if (shoulderDistance < 24)
                //    {
                //        controller.SimpleMove(moveDirection * 0);
                //    }
                //}
                break;

            }
        }
	}
}
