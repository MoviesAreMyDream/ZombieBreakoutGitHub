using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class KinectGravGun : MonoBehaviour {

    public float catchRange = 30.0f;
    public float holdDistance = 4.0f;
    public float minForce = 1000;
    public float maxForce = 10000;
    public float forceChargePerSec = 3000;
    public LayerMask layerMask = -1;
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
    private BodyFrameReader _Reader;
    private KinectSensor _Sensor;
    private Body[] data = null;

    enum GravityGunState {
        Free,
        Catch,
        Occupied,
        Charge,
        Release
    };

    private GravityGunState gravityGunState = 0;
    public Rigidbody rigid = null;
    private float currentForce;

    public Body[] GetData()
    {
        return data;
    }

	void Start ()
    {
        currentForce = minForce;
        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            _Reader = _Sensor.BodyFrameSource.OpenReader();

            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }
    }

    void FixedUpdate()
    {
        if (_Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();

            if (frame != null)
            {
                if (data == null)
                {
                    data = new Body[_Sensor.BodyFrameSource.BodyCount];
                }

                frame.GetAndRefreshBodyData(data);

                frame.Dispose();
                frame = null;

                int idx = 0;
                for (int i = 0; i < _Sensor.BodyFrameSource.BodyCount; i++)
                {
                    if (data[i].IsTracked)
                    {
                        idx = i;
                    }
                }
                /*
                if (idx > -1)
                {
                    if (data[idx].HandRightState != HandState.Closed)
                    {

                    }


                }
                if (data[idx].HandLeftState != HandState.Closed)
                {

                }
                */

                if (gravityGunState == GravityGunState.Free)
                {
                    if (data[idx].HandLeftState == HandState.Closed)
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(transform.position, transform.forward, out hit, catchRange, layerMask))
                        {
                            if (hit.rigidbody)
                            {
                                rigid = hit.rigidbody;
                                gravityGunState = GravityGunState.Catch;
                            }
                        }
                    }
                }

                else if (gravityGunState == GravityGunState.Catch)
                {
                    rigid.MovePosition(transform.position + transform.forward * holdDistance);
                    if (data[idx].HandLeftState != HandState.Closed)
                        gravityGunState = GravityGunState.Occupied;
                }

                else if (gravityGunState == GravityGunState.Occupied)
                {
                    rigid.MovePosition(transform.position + transform.forward * holdDistance);
                    if (data[idx].HandLeftState == HandState.Closed)
                        gravityGunState = GravityGunState.Charge;
                }

                else if (gravityGunState == GravityGunState.Charge)
                {
                    rigid.MovePosition(transform.position + transform.forward * holdDistance);
                    if (currentForce < maxForce)
                    {
                        currentForce += forceChargePerSec * Time.deltaTime;
                    }

                    else
                    {
                        currentForce = maxForce;
                    }

                    if (data[idx].HandLeftState != HandState.Closed)
                        gravityGunState = GravityGunState.Release;
                }

                else if (gravityGunState == GravityGunState.Release)
                {
                    rigid.AddForce(transform.forward * currentForce);
                    currentForce = minForce;
                    gravityGunState = GravityGunState.Free;
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
