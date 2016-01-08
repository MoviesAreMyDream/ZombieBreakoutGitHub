using UnityEngine;
using System.Collections;

public class BloodScript : MonoBehaviour {

    private GameObject emitterGO;
    private GameObject emitter2GO;
    private ParticleEmitter emitter;
    private ParticleEmitter emitter2;

	void Start () {
        emitterGO = GameObject.Find("MainBlood");
        emitter = emitterGO.GetComponent<ParticleEmitter>();
        emitter2GO = GameObject.Find("DropsBlood");
        emitter2 = emitter2GO.GetComponent<ParticleEmitter>();

		StartCoroutine(BloodTime());
	}
    
    IEnumerator BloodTime ()
    {
        
		emitter.emit = true;
        emitter2.emit = true;
        yield return new WaitForSeconds(0.1f);
        emitter.emit = false;
        emitter2.emit = false;
        Destroy(gameObject, 0.5f);
    }


}
