using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class KinectShoot : MonoBehaviour
{
    public GameObject muzzleFlash;
    public Rigidbody bullet;
    public float velocity = 10.0f;
    public float FireRate = 1.0f;
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
    private KinectSensor _Sensor;
    private bool Fired = false;

    // Update is called once per frame
    void Update()
    {
        Fired = false;
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
                    if (data[0].HandRightState == HandState.Open)
                    {
                        Fire();
                    }
                    if (data[0].HandRightState == HandState.Closed)
                    {
                        Fired = false;
                    }
                    else
                    {
                        return;
                    }
            }
       }
    }

    void Fire()
    {
        Fired = false;
        Instantiate(muzzleFlash, transform.position, transform.rotation);
       // yield return new WaitForSeconds(FireRate);
        Rigidbody newBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
        newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
        Fired = true;
    }
}