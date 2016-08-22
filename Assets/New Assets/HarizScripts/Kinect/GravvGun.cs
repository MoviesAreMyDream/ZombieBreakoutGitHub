using UnityEngine;
using System.Collections;

public class GravvGun : MonoBehaviour {

    public float catchRange = 30.0f;
    public float holdDistance = 4.0f;
    public float minForce = 1000;
    public float maxForce = 10000;
    public float forceChargePerSec = 3000;
    public LayerMask layerMask = -1;

    enum GravityGunState
    {
        Free,
        Catch,
        Occupied,
        Charge,
        Release
    };

    private GravityGunState gravityGunState = 0;
    public Rigidbody rigid = null;
    private float currentForce;

    void Start () {
        currentForce = minForce;
    }

    void FixedUpdate()
    {
        if (gravityGunState == GravityGunState.Free)
        {
            if (Input.GetButton("Fire1"))
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
            if (!Input.GetButton("Fire1"))
                gravityGunState = GravityGunState.Occupied;
        }

        else if (gravityGunState == GravityGunState.Occupied)
        {
            rigid.MovePosition(transform.position + transform.forward * holdDistance);
            if (Input.GetButton("Fire1"))
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

            if (!Input.GetButton("Fire1"))
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
