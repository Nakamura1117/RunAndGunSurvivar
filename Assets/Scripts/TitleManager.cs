using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    [Header("スタート時のシーン")]
    public string nextScene;

    void Awake()
    {
        GetComponent<PlayerInput>().enabled = false;
        Invoke("ControllerOn", 0.2f);
    }
    void OnAttack(InputValue value)
    {
        Debug.Log("onattack");
        SceneChange();
    }

    public void SceneChange()
    {
        //Debug.Log("scenechange");

        // トータルスコアをリセット
        ScoreManager.totalScore = 0;
        SceneManager.LoadScene(nextScene);
    }

    private void ControllerOn()
    {
        GetComponent<PlayerInput>().enabled = true;
    }
}
