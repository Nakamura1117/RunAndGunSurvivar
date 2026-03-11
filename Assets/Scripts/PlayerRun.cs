using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRun : MonoBehaviour
{

    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 2.5f;
    const int DefaultLife = 3;
    const float StunDuration = 0.5f;

    CharacterController controller;

    public GameObject animeBody;
    Animator animator;
    bool isAnime;

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

    [Header("ソードのスクリプト")]
    public NormalSword normalSword;

    AudioSource[] playerAudio;
    float footstepInterval = 0.3f;
    float footstepTimer;

    [Header("SE音源")]
    public AudioClip se_Walk;
    public AudioClip se_Damage;
    public AudioClip se_Explosion;
    public AudioClip se_Jump;
    public AudioClip se_Dash;
    public AudioClip se_Reload;

    // PlayerオブジェクトについているAudioSouceの１番目は「Player」自身のオーディオ
    private static readonly int audioPlayer = 0;
    // PlayerオブジェクトについているAudioSouceの２番目は「Walk（歩き）」のオーディオ
    private static readonly int audioWalk = 1;
    // PlayerオブジェクトについているAudioSouceの３番目が「Damage（ダメージ時）」のオーディオ
    private static readonly int audioDamage = 2;

    void Awake()
    {
        GetComponent<PlayerInput>().enabled = false;
        Invoke("ControllerOn", 1.0f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.gameState = GameState.gameplay;
        controller = GetComponent<CharacterController>();
        animator = animeBody.GetComponent<Animator>();

        playerAudio = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.gameState == GameState.stageclear || GameManager.gameState == GameState.result) return;

        //if (Input.GetKeyDown("left")) MoveToLeft();
        //if (Input.GetKeyDown("right")) MoveToRight(); 
        //if (Input.GetKeyDown("space")) Jump();

        if (currentMoveInputX < 0)
        {
            MoveToLeft();
        }
        else if (currentMoveInputX > 0)
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

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

            if (controller.isGrounded) moveDirection.y = 0;
        }
    }

    void FixedUpdate()
    {
        HandleFootsteps();
    }

    void OnMove(InputValue value)
    {
        if (normalSword.GetIsSword()) return;
        if (resetIntervalCol == null)
        {
            Vector2 axisX = value.Get<Vector2>();
            currentMoveInputX = axisX.x;
        }
    }

    void OnJump(InputValue value)
    {
        if (normalSword.GetIsSword()) return;
        Jump();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (isStun()) return;
        if (hit.gameObject.tag == "Enemy")
        {
            playerAudio[audioDamage].PlayOneShot(se_Damage);

            LifeDown();
            GetComponent<NormalShooter>().ShootPowerDown();
            recoverTime = StunDuration;


            if (GetLife() <= 0)
            {
                GameManager.gameState = GameState.gameover;
                if (!(isAnime))
                {
                    animator.SetTrigger("retry");
                    isAnime = true;
                }
            }

            hit.gameObject.GetComponent<Wall>().CreateEffect();
            animator.SetTrigger("damage");

            //Destroy(hit.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            GameManager.gameState = GameState.stageclear;
            if (!(isAnime))
            {
                animator.SetTrigger("goal");
                isAnime = true;

                playerAudio[audioPlayer].PlayOneShot(se_Reload);
            }
            Destroy(other.gameObject);
        }
    }

    public int GetLife()
    {
        return life;
    }

    public void LifeUp(int value = 1)
    {
        life += value;
        if (life > DefaultLife) life = DefaultLife;

        GameObject canvas = GameObject.FindGameObjectWithTag("UI");
        canvas.GetComponent<UIController>().UpdateLife(GetLife());
    }

    public void LifeDown(int value = 1)
    {
        life -= value;
        if (life > DefaultLife) life = DefaultLife;

        GameObject canvas = GameObject.FindGameObjectWithTag("UI");
        canvas.GetComponent<UIController>().UpdateLife(GetLife());
    }

    private void Jump()
    {
        if (isStun()) return;
        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;
            animator.SetTrigger("jump");
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

            playerAudio[audioPlayer].PlayOneShot(se_Dash);
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

            playerAudio[audioPlayer].PlayOneShot(se_Dash);
        }
    }

    private bool isStun()
    {
        return (recoverTime > 0 || life <= 0);
    }

    void HandleFootsteps()
    {
        //地面にいてプレイヤーが動いていれば
        if (controller.isGrounded && moveDirection.z != 0)
        {
            footstepTimer += Time.deltaTime; //時間計測

            if (footstepTimer >= footstepInterval) //インターバルチェック
            {
                playerAudio[audioWalk].PlayOneShot(se_Walk);
                footstepTimer = 0;
            }
        }
        else //動いていなければ時間計測リセット
        {
            footstepTimer = 0f;
        }
    }

    void ControllerOn()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.enabled = true;
        playerInput.SwitchCurrentActionMap("Player");
    }

    IEnumerator ResetIntervalCol()
    {
        yield return new WaitForSeconds(0.1f);
        resetIntervalCol = null;
    }


}
