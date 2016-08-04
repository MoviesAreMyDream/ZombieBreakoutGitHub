
using UnityEngine;
using System.Collections;
using Windows.Kinect;
public class KinectJointRotation : MonoBehaviour
{
    public GameObject _Player; //Attach player here
    public GameObject _bodySourceManager; //Attach BodyManager in Scene Hiererachy here
    public float RotationSpeed = 0.5f; //Dont make it too fast or else people will experience motion sickness

    private JointType _jointTypeS = JointType.SpineBase; //Spine
    private BodySourceManager _bodyManager;
    private float TurnDirMultiplier; //How much the player rotates in angles. Default is 1.0
    private bool TurnRight;
    private bool TurnLeft;

    void Start()
    {
        if(_Player == null)
        {
           _Player = GameObject.FindGameObjectWithTag("Player");
        }

        _bodySourceManager = GameObject.Find("BodyManager");
    }

    void Update()
    {
        if (_bodySourceManager == null)                                         //
        {                                                                       //
            return;                                                             //
        }                                                                       //
                                                                                //
        _bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();    //
        if (_bodyManager == null)                                               //
        {                                                                       //
            return;                                                             //
        }                                                                       //
                                                                                //      Getting data from Kinect sensors
        Body[] data = _bodyManager.GetData();                                   //
        if (data == null)                                                       //
        {                                                                       //
            return;                                                             //
        }                                                                       //
                                                                                //
        foreach (var body in data)                                              //
        {                                                                       //
            if (body == null)                                                   //
            {                                                                   //
                continue;                                                       //
            }                                                                   //

            if (body.IsTracked)
            {
                var turnDegree = body.JointOrientations[_jointTypeS].Orientation.W * 100; //get orientation of joint multiplied by 100 because default value is too small
                //Debug.Log(turnDegree);                                                  //What is .W? Nobody knows ༼ つ◕_◕ ༽つ 
                if (Mathf.Abs(turnDegree) >= 16)                                         //Maybe w= cos(theta/2) where theta is rotation angle around the axis of the quaternion?
                {
                    TurnRight = true;
                    TurnLeft = false;
                    if (turnDegree < -5)
                    {
                        TurnLeft = true;
                        TurnRight = false;
                    }
                }
                
                if(turnDegree >= 0)
                {
                    if(Mathf.Abs(turnDegree) < 25)
                    {
                        TurnLeft = false;
                        TurnRight = false;
                    }
                }
                
                if(TurnRight == true)
                {
                        TurnDirMultiplier = 1.2f;
                        transform.rotation *= Quaternion.Euler(0, RotationSpeed * TurnDirMultiplier, 0);
                }

                if (TurnRight == false)
                {
                        TurnDirMultiplier = 0;
                        transform.rotation *= Quaternion.Euler(0, RotationSpeed * TurnDirMultiplier, 0);
                }

                if (TurnLeft == true)
                {
                        TurnDirMultiplier = -1.2f;
                        transform.rotation *= Quaternion.Euler(0, RotationSpeed * TurnDirMultiplier, 0);
                }

                if (TurnLeft == false)
                {
                        TurnDirMultiplier = 0;
                        transform.rotation *= Quaternion.Euler(0, RotationSpeed * TurnDirMultiplier, 0);
                }
                break;
            }
        }
    }
}
