using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

    public float MainDamage = 1.0f;
	public string DamageMethodName = "Damage"; 

	private PlayerHealthNewChar health;
	

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }
    

	void OnTriggerStay(Collider other) {

		if (other.gameObject.tag == "Player") {
          
//			if (anim.GetFloat ("PlayerStillThere") == 3) {
//				health = other.GetComponent<PlayerHealthNewChar>();
//
//
//				if (health != null) {
//					health.remove (MainDamage);
				
//				}
//	
//			}
		}
		
	}
	
}
