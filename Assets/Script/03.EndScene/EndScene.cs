using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndScene : MonoBehaviour
{
    //button.onclick.AddListner() ����غ����� �õ�...
    //Button restartBtn;
    [Serializable]
    public class Members
    {
        public GameObject memberCharacter;
        public Sprite idle;
        public Sprite jump;
    }

    public List<Members> memberList = new List<Members>();

    public void Start()
    {
        float dealy = 0f;
        foreach (var member in memberList)
        {
            SpriteRenderer sr = member.memberCharacter.AddComponent<SpriteRenderer>();
            Vector2 initPos = member.memberCharacter.transform.position;

            Sequence s = DOTween.Sequence();

            s.AppendInterval(dealy);

            s.AppendCallback(() => sr.sprite = member.jump)
                .Append(member.memberCharacter.transform.DOLocalMoveY(initPos.y + 0.5f, 0.5f)
                ).AppendInterval(0.1f);

            s.AppendCallback(() => sr.sprite = member.idle)
                .Append(member.memberCharacter.transform.DOLocalMoveY(initPos.y, 0.5f));

            s.SetLoops(-1, LoopType.Yoyo);

            dealy += 0.5f;
        }
    }

    public void Restart()
    {
        //restartBtn = transform.GetChild(0).GetComponent<Button>();
        //restartBtn.onClick.AddListener(() => SceneManager.LoadScene("PlayScene"));

        // �����÷��� ȭ������
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        //button.onClick.AddListener();

        // ����ȭ������
        SceneManager.LoadScene("Start");
    }
}
