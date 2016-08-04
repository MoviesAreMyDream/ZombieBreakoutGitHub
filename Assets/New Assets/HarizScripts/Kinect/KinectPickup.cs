using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class KinectPickup : MonoBehaviour
{
    public Transform player;
    public float throwForce = 10;
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
    private KinectSensor _Sensor;
    bool hasPlayer = false;
    bool beingCarried = false;

    void OnTriggerEnter(Collider other)
    {
        hasPlayer = true;
    }

    void OnTriggerExit(Collider other)
    {
        hasPlayer = false;
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
                if (beingCarried)
                {
                    if (data[0].HandLeftState == HandState.Closed)
                    {
                        GetComponent<Rigidbody>().isKinematic = false;
                        transform.parent = null;
                        beingCarried = false;
                        GetComponent<Rigidbody>().AddForce(player.forward * throwForce);
                    }
                }
                else
                {
                    if (data[0].HandLeftState == HandState.Open && hasPlayer)
                    {
                        GetComponent<Rigidbody>().isKinematic = true;
                        transform.parent = player;
                        beingCarried = true;
                    }
                }
            }
        }
    }
}