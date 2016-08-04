using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class KinectWeaponAim : MonoBehaviour {

    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private Body[] _Data = null;

    public GameObject _Player;
    public float XSensitivity;
    public float YSensitivity;
    public float ZSensitivity;
    public float RotationSensitivity;
    public JointType _jointType;

    float horizontal;
    float vertical;
    float angley;
    float anglex;
    float anglez;
    float rotationX;
    float rotationY;
    float rotationZ;

    public Body[] GetData()
    {
        return _Data;
    }

	// Use this for initialization
	void Start () {
        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            _Reader = _Sensor.BodyFrameSource.OpenReader();

            if(!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }

        if (_Player == null)
        {
            _Player = GameObject.FindGameObjectWithTag("Player");
        }
    }
	

	// Update is called once per frame
	void Update () {
        if ( _Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();

            if (frame != null)
            {
                if (_Data == null)
                {
                    _Data = new Body[_Sensor.BodyFrameSource.BodyCount];
                }

                frame.GetAndRefreshBodyData(_Data);

                frame.Dispose();
                frame = null;

                int idx = 0;
                for (int i = 0; i < _Sensor.BodyFrameSource.BodyCount; i++)
                {
                    if (_Data[i].IsTracked)
                    {
                        idx = i;
                    }
                }

                if (_Data[idx].HandLeftState != HandState.Closed)
                {
                    angley =
                         (float)(_Data[idx].Joints[_jointType].Position.X);
                    anglex =
                        (float)(_Data[idx].Joints[_jointType].Position.Y);
                    anglez = 
                        (float)(_Data[idx].Joints[_jointType].Position.Z);
                  
                    rotationX = Mathf.Clamp(this.gameObject.transform.rotation.x + -1 * anglex * RotationSensitivity + _Player.transform.rotation.x, -90 ,90);//clamp min/max angle of rotation of X axis 
                    rotationY = Mathf.Clamp(this.gameObject.transform.rotation.y + angley * RotationSensitivity + _Player.transform.rotation.y, -45, 45);
                    rotationZ = Mathf.Clamp(this.gameObject.transform.rotation.z + anglez * RotationSensitivity + _Player.transform.rotation.z, 0, 0);//clamp min/max angle of rotation of Z axis; set to 0 in this case because other values result in the gun being positioned in an odd angle
                   
                    this.gameObject.transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
                }
            }
        }
	}

    void OnApplicationQuit() //Remove Kinect Data after game closes
    {
        if (_Reader != null)
        {
            _Reader.Dispose();
            _Reader = null;
        }

        if (_Sensor != null)
        {
            if (_Sensor != null)
            {
                if (_Sensor.IsOpen)
                {
                    _Sensor.Close();
                }
                _Sensor = null;
            }
        }
    }
}

