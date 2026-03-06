using System.Collections;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRun : MonoBehaviour
{

    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    const int DefaultLife = 3;
    const float StunDuration = 0.5f;

    CharacterController controller;
    //Animator animator;

    Vector3 moveDirection = Vector3.zero;
    int targetLane;
    int life = DefaultLife;
    float recoverTime = 0.0f;

    float currentMoveInputX;
    Coroutine resetIntervalCol;

    public float gravity = 20.0f;
    public float speedZ = 5.0f;
    public float speedX = 3.0f;
    public float speedJump = 8.0f;
    public float accelerationZ = 10.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("left")) MoveToLeft();
        //if (Input.GetKeyDown("right")) MoveToRight(); 
        //if (Input.GetKeyDown("space")) Jump();

        if (currentMoveInputX > 0)
        {
            MoveToLeft();
        }
        else if (currentMoveInputX < 0)
        {
            MoveToRight();
        }

        if (isStun())
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            float acceleratedZ = moveDirection.z + accelerationZ * Time.deltaTime;
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
            moveDirection.x = ratioX * speedX;

            moveDirection.y -= gravity* Time.deltaTime;
            controller.Move(moveDirection*Time.deltaTime);

            if (controller.isGrounded) moveDirection.y = 0;
        }

    }

    void OnMove(InputValue value)
    {
        if (resetIntervalCol == null)
        {
            
            Vector2 axisX = value.Get<Vector2>();
            currentMoveInputX = axisX.x;
            Debug.Log(currentMoveInputX);
        }
    }

    void OnJump(InputValue value)
    {
        Jump();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (isStun()) return;
        if (hit.gameObject.tag =="Enemy")
        {
            life--;
            recoverTime = StunDuration;
            //hit.gameObject.GetComponent<>.CreateEffect();
            Destroy(hit.gameObject);
        }
    }

    public int GetLife()
    {
        return life;
    }

    public void LifeUp()
    {
        if (life < DefaultLife)
        {
            life++;
        }
    }

    private void Jump()
    {
        if (isStun()) return;
        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;
        }
    }

    private void MoveToLeft()
    {
        if (isStun()) return;
        if (controller.isGrounded && targetLane > MinLane)
        {
            targetLane--;
            currentMoveInputX = 0;
            StartCoroutine(ResetIntervalCol());
        }
    }
    private void MoveToRight()
    {
        if (isStun()) return;
        if (controller.isGrounded && targetLane < MaxLane)
        {
            targetLane++;
            currentMoveInputX = 0;
            StartCoroutine(ResetIntervalCol());
        }
    }

    private bool isStun()
    {
        return (recoverTime > 0 || life <= 0);
    }

    IEnumerator ResetIntervalCol()
    {
        yield return new WaitForSeconds(0.1f);
        resetIntervalCol = null;
    }
}
