using System.Collections;
using Unity.VisualScripting;
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

    //InputAction(Playerマップ)のAttackアクションがおされたら


    void OnAttack(InputValue value)
    {
        Shoot();
    }

    void Shoot()
    {
        if (bulletManager.GetBulletRemaining() > 0)
        {
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

    void Start()
    {
        bullets = GameObject.FindGameObjectWithTag("Bullets");
    }
}
