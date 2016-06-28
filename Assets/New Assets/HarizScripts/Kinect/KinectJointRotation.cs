using UnityEngine;
using System.Collections;
using Windows.Kinect;
public class KinectJointRotation : MonoBehaviour
{
    public GameObject _Player;
    public GameObject _bodySourceManager;
    public float RotationSpeed = 0.5f;
    private JointType _jointTypeS = JointType.SpineBase;
    private BodySourceManager _bodyManager;
    private float TurnDirMultiplier;
    private bool Turn;
    private bool TurnRight;
    private bool TurnLeft;

    void Start()
    {
        if(_Player == null)
        {
           _Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
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
                var turnDegree = body.JointOrientations[_jointTypeS].Orientation.W * 100;
                //Debug.Log(turnDegree);
                if(Mathf.Abs(turnDegree) >= 25 )
                {
                    TurnRight = true;
                    TurnLeft = false;
                    if (turnDegree < 0)
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
                        TurnDirMultiplier = 1;
                        transform.rotation *= Quaternion.Euler(0, RotationSpeed * TurnDirMultiplier, 0);
                }

                if (TurnRight == false)
                {
                    TurnDirMultiplier = 0;
                    transform.rotation *= Quaternion.Euler(0, RotationSpeed * TurnDirMultiplier, 0);
                }

                if (TurnLeft == true)
                {
                        TurnDirMultiplier = -1;
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
