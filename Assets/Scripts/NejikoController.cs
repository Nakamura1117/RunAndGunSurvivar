using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class NejikoController : MonoBehaviour
{
    CharacterController controller;
    Animator animator;

    Vector3 moveDirection = Vector3.zero;


    public float gravity;
    public float speedz;
    public float speedJump;

    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    const int DefaultLife = 3;
    const float StunDuration = 0.5f;

    int targetRane;
    int line = DefaultLife;
    float recoverTime = 0.0f;
    float currentMoveInputX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            //if (Input.GetAxis("Vertical") != 0.0f) // これでも下の式と同等になりそうメモ
            if (Input.GetAxis("Vertical") > 0.0f || Input.GetAxis("Vertical") < 0.0f)
            {
                moveDirection.z = Input.GetAxis("Vertical") * speedz;

            }
            else
            {
                moveDirection.z = 0;
            }

            transform.Rotate(0, Input.GetAxis("Horizontal") * 3, 0);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = speedJump;
                // animator.SetTrigger("jump");
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        if (controller.isGrounded) moveDirection.y = 0;
        // animator.SetBool("run", moveDirection.z > 0.0f);
    }
}
