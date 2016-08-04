using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class BodySourceManager : MonoBehaviour 
{
    private KinectSensor _Sensor;//Access the Kinect Sensor; provides properties which allows us to get sources references
    private BodyFrameReader _Reader;//Gets relevant information for body movement
    private Body[] _Data = null;//Stores current information about the body
    
    public Body[] GetData()
    {
        return _Data;
    }
    

    void Start () //Initialize Kinect sensors
    {
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
    
    void Update () 
    {
        if (_Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();
            if (frame != null)
            {
                if (_Data == null)
                {
                    _Data = new Body[_Sensor.BodyFrameSource.BodyCount]; //Detect bodies
                }
                
                frame.GetAndRefreshBodyData(_Data);
                
                frame.Dispose();
                frame = null;

                int idx = -1;
                for (var i = 0; i < 6; i++)
                {
                    if(_Data[i].LeanTrackingState != TrackingState.NotTracked)
                    {
                        idx = i;
                    }
                }
            }
        }    
    }
    
    void OnApplicationQuit() //Clear Kinect data
    {
        if (_Reader != null)
        {
            _Reader.Dispose();
            _Reader = null;
        }
        
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
