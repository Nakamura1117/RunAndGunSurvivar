using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [Header("生成プレハブオブジェクト")]
    public GameObject effectPrefab; //生成プレハブ

    [Header("耐久力")]
    public float life = 5.0f; //耐久力

    [Header("ダメージ時間・振動対象・振動スピード・振動量")]
    public float damegeTime = 0.25f; //ダメージ中時間
    public GameObject damageBody; //振動対象オブジェクト
    public float speed = 75.0f; //振動スピード
    public float amplitude = 1.5f;  //振動量

    Vector3 startPosition; //振動対象の初期位置
    float x; //振動による移動座標

    Coroutine currentDamage; //ダメージコルーチン

    [Header("スコア")]
    public int scorePoint = 100;

    AudioSource[] enemyAudio;
    [Header("SE音源")]
    public AudioClip se_Damage;

    void Start()
    {
        startPosition = damageBody.transform.localPosition;
        enemyAudio = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (currentDamage != null)
        {
            x = (amplitude * 0.01f) * Mathf.Sin(Time.time * speed);
            damageBody.transform.localPosition = startPosition - new Vector3(x, 0, 0);
        }
    }

    //衝突
    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Bullet" || tag == "Sword")
        {
            if (currentDamage != null) return;
            enemyAudio[0].PlayOneShot(se_Damage);
            currentDamage = StartCoroutine(DamageCol(tag));
            if (life <= 0)
            {
                CreateEffect();
            }
        }
    }

    public void CreateEffect()
    {
        if (effectPrefab != null)
        {
            GameObject deefeatEffect = Instantiate(
                effectPrefab,
                transform.position,
                Quaternion.identity);
            ScoreManager.ScoreUp(scorePoint);
            Destroy(gameObject);
        }
    }
    //ダメージコルーチン
    IEnumerator DamageCol(string tag)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (tag == "Bullet")
        {
            life -= player.gameObject.GetComponent<NormalShooter>().GetShootPower();
        }
        else if (tag == "Sword")
        {
            life -= player.gameObject.GetComponent<NormalSword>().GetSwordPower();
        }


        yield return new WaitForSeconds(damegeTime);
        currentDamage = null;
        yield return new WaitForSeconds(0.1f);
        damageBody.transform.localPosition = startPosition;

    }
}
