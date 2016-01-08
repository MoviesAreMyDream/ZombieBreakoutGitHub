using UnityEngine;
using System.Collections;

public class AfterDeath : MonoBehaviour {

    private GameObject CharAnimGO;
    private Animation CharAnim;

    void Start () {
        CharAnimGO = GameObject.Find("OVRCameraRig");
        CharAnim = CharAnimGO.GetComponent<Animation>();
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence ()
    {
        CharAnim.Play("OVRCamDeathAnim");
        yield return new WaitForSeconds(CharAnim.GetClip("OVRCamDeathAnim").length);
        print("now we dead");
        CharAnim.Play("OVRCamAfterDeath");
        gameObject.GetComponent<PlayerHealthNewChar>().enabled = false;
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.GetComponent<NewControllerControls>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<OVRGamepadController>().enabled = false;
        gameObject.GetComponent<OVRPlayerController>().enabled = false;
        gameObject.GetComponent<OVRDebugInfo>().enabled = false;
		Time.timeScale = 0;
    }

}
