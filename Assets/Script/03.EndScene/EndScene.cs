using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    //button.onclick.AddListner() 사용해보려고 시도...
    //Button restartBtn;
    public void Restart()
    {
        //restartBtn = transform.GetChild(0).GetComponent<Button>();
        //restartBtn.onClick.AddListener(() => SceneManager.LoadScene("PlayScene"));

        // 게임플레이 화면으로
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        //button.onClick.AddListener();

        // 메인화면으로
        SceneManager.LoadScene("Start");
    }
}
