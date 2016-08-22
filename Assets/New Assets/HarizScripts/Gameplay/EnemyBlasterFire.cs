using UnityEngine;
using System.Collections;

public class EnemyBlasterFire : MonoBehaviour
{
    public GameObject rBlasterBolt;
    public float fVelocity;
    public float DamagePoints;

    private GameObject Target;
    private PlayerHealthNewChar healthScript;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        healthScript = Target.GetComponent<PlayerHealthNewChar>();
    }

    public void Shoot()
    {
        Rigidbody newBlast = Instantiate(rBlasterBolt, transform.position, transform.rotation) as Rigidbody;
        newBlast.AddForce(transform.forward * fVelocity, ForceMode.VelocityChange);

        Destroy(newBlast.gameObject, 3f);
    }



    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            healthScript = col.gameObject.GetComponent< PlayerHealthNewChar > ();
            healthScript.remove(DamagePoints);
        }

    }
}