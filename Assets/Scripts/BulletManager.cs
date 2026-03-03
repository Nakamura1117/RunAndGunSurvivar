using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    const int maxRemaining = 10; //充填数の上限

    [Header("弾数・保有マガジン数")]
    public int bulletRemaining = maxRemaining; //残弾数
    public int magazine = 1; //マガジン数 ※充填時に消費

    [Header("充填時間")]
    public float recoveryTime = 3.0f; //マガジン補充時間
    float counter; //充填までの残時間

    Coroutine bulletRecover; //発生中のコルーチン情報の参照用
    float remainingTime = 0.0f;


    //弾の消費
    public void ConsumeBullet()
    {
        if (bulletRemaining > 0)
        {
            bulletRemaining--;
        }
    }

    //残数の取得
    public int GetBulletRemaining()
    {
        return bulletRemaining;
    }

    //弾の充填

    public void AddBullet()
    {
        bulletRemaining = maxRemaining;
    }
    public void AddBullet(int num)
    {
        bulletRemaining = num;
    }

    //充填メソッド
    public void RecoverBullet()
    {
        if (bulletRecover == null)
        {
            if (magazine > 0)
            {
                bulletRecover = StartCoroutine(RecoverBulletCol(recoveryTime));
                magazine--;
            }
        }
    }

    //充填コルーチン
    IEnumerator RecoverBulletCol(float waitTime)
    {
        const float minCnt = 1.0f;
        remainingTime = waitTime;
        while (remainingTime > 0) { 
            yield return new WaitForSeconds(minCnt);
            remainingTime -= minCnt;
        }
        AddBullet(maxRemaining);
        bulletRecover = null;

    }

    //画面上に簡易GUI表示
    void OnGUI()
    {
        string label;
        if (bulletRecover != null)
        {
            GUI.color = Color.red;
            if (Mathf.Sin(Time.time) * 50 > 0)
            {
                label = "";
            }
            else
            {
                label = "bulletRecover:" + remainingTime;
            }
            GUI.Label(new Rect(50, 25, 150, 50), label);
        }

        GUI.color = Color.black;
        label = "bullet:" + bulletRemaining;
        GUI.Label(new Rect(50,50, 100, 50), label);

        GUI.color = Color.black;
        label = "magazin:" + magazine;
        GUI.Label(new Rect(50, 75, 150, 50), label);
    }
}
