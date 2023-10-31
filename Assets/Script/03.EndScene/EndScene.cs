using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EneScene : MonoBehaviour
{
    //button.onclick.AddListner() 사용해보려고 시도...
    //Button restartBtn;
    void Restart()
    {
        //restartBtn = transform.GetChild(0).GetComponent<Button>();
        //restartBtn.onClick.AddListener(() => SceneManager.LoadScene("PlayScene"));
        SceneManager.LoadScene("PlayScene");
    }

    void Exit()
    {
        //button.onClick.AddListener();
        SceneManager.LoadScene("MainScene");
    }
}
