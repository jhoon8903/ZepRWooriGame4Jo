using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class EndScenejj : MonoBehaviour
{
    //button.onclick.AddListner()
    //Button restartBtn;
    public GameObject memberCharacter;

    // Start is called before the first frame update
    void Start()
    {
        // memberCharacter.transform.DOMoveY(1, 1).SetLoops(-1, LoopType.Restart);
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(memberCharacter.transform.DOMoveY(1, 0.3f)); // Y 좌표를 1로 이동
        moveSequence.Append(memberCharacter.transform.DOMoveY(0, 0.5f)); // Y 좌표를 0으로 이동
        moveSequence.AppendInterval(0.5f);
        moveSequence.SetLoops(-1, LoopType.Restart); // 루프 설정
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        //restartBtn = transform.GetChild(0).GetComponent<Button>();
        //restartBtn.onClick.AddListener(() => SceneManager.LoadScene("PlayScene"));

        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        //button.onClick.AddListener();

        SceneManager.LoadScene("Start");
    }
}
