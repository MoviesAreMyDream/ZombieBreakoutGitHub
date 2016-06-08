using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour {

    public GameObject fireExplosion;
    public float damage = 10f;


    void Start()
    { }

    void OnTriggerEnter(Collider hit)
    {
        //		print("hitting");

        GameObject smoke = GameObject.Instantiate(fireExplosion, transform.position, fireExplosion.transform.rotation) as GameObject;
        GameObject.Destroy(smoke, 2f);
        //		print("colliding");

        if (hit.gameObject.tag == "Player")
        {
            hit.gameObject.GetComponent<intruderDUKE>().ApplyDamage(damage);
        }

    }

    void OnTriggerExit(Collider hit)
    {
        //		print("out of collider");
        Destroy(this);
    }
}
