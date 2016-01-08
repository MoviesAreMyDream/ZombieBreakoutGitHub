using UnityEngine;
using System.Collections;

public class NewControllerControls : MonoBehaviour {

    public float speed = 4.0F;
    public float runSpeed = 8.0f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    GameObject MainCam;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

            if (Input.GetAxis("LTrigger") >= 0.1)
                moveDirection *= runSpeed;
            else
                moveDirection *= speed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("RHorizontal")*5, 0);
    }
}
