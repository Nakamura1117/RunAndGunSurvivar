
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalShooter : MonoBehaviour
{
    [Header("Bullet管理スクリプトと連携")]
    public BulletManager bulletManager;

    [Header("生成オブジェクトと位置")]
    public GameObject bulletPrefabs;//生成対象プレハブ
    public GameObject gate; //生成位置

    [Header("弾速")]
    public float shootSpeed = 10.0f; //弾速

    GameObject bullets; //生成した弾をまとめるオブジェクト

    const int maxShootPower = 3;
    int shootPower = 1;
    //[Header("ソードのスクリプト")]
    //public NomalSword normalSword;

    //InputAction(Playerマップ)のAttackアクションがおされたら

    AudioSource[] playerAudio;
    [Header("SE音源")]
    public AudioClip se_Shot;


    void OnAttack(InputValue value)
    {
        //if (normalSword.GetIsSword()) return;

        if (GameManager.gameState == GameState.retry)
        {
            GameManager.RetryScene();
        }
        else if (GameManager.gameState == GameState.result)
        {
            GameManager gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
            gm.NextScene(gm.nextScene);
        }
        else
        {
            Shoot();
        }

    }

    void Shoot()
    {
        if (bulletManager.GetBulletRemaining() > 0)
        {
            playerAudio[0].PlayOneShot(se_Shot);
            GameObject obj = Instantiate(
                bulletPrefabs,
                gate.transform.position,
                Quaternion.Euler(90, 0, 0),
                bullets.transform
                );
            bulletManager.ConsumeBullet();
            Rigidbody bulletRbody = obj.GetComponent<Rigidbody>();
            bulletRbody.AddForce(new Vector3(0, 0, 1) * shootSpeed, ForceMode.Impulse);
        }
        else
        {
            bulletManager.RecoverBullet();
        }
    }

    public void ShootPowerUp(int value = 1)
    {
        shootPower += value;
        if (shootPower > maxShootPower) shootPower = maxShootPower;
        GameObject canvas = GameObject.FindGameObjectWithTag("UI");
        canvas.GetComponent<UIController>().UpdateGun();
    }


    public void ShootPowerDown(int value = 1)
    {
        shootPower -= value;
        if (shootPower <= 0) shootPower = 1;
        GameObject canvas = GameObject.FindGameObjectWithTag("UI");
        canvas.GetComponent<UIController>().UpdateGun();
    }

    public int GetShootPower()
    {
        return shootPower;
    }

    void Start()
    {
        bullets = GameObject.FindGameObjectWithTag("Bullets");

        playerAudio = GetComponents<AudioSource>();
    }
}
