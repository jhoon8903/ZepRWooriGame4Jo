using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndScene : MonoBehaviour
{
    //button.onclick.AddListner()
    //Button restartBtn;

    //[Serializable]
    //public class Members
    //{
    //    public GameObject memberCharacter;
    //    public Sprite idle;
    //    public Sprite jump;
    //}

    //public List<Members> memberList = new List<Members>();

    public void Start()
    {
        //float delay = 0f; // 애니메이션 간의 시작 딜레이를 설정하는 변수

        //foreach (var member in memberList) // 멤버 리스트를 순회
        //{
        //    SpriteRenderer sr = member.memberCharacter.AddComponent<SpriteRenderer>(); // 멤버 캐릭터에 SpriteRenderer 컴포넌트를 추가하고 해당 참조를 sr 변수에 저장
        //    Vector2 initPos = member.memberCharacter.transform.position; // 멤버 캐릭터의 초기 위치를 저장

        //    Sequence s = DOTween.Sequence(); // DOTween의 시퀀스를 생성하여 애니메이션 시퀀스를 설정

        //    s.AppendInterval(delay); // 지정된 딜레이 시간을 기다린 후에 애니메이션을 시작

        //    s.AppendCallback(() => sr.sprite = member.jump) // jump 스프라이트로 변경하는 콜백 애니메이션을 추가
        //        .Append(member.memberCharacter.transform.DOLocalMoveY(initPos.y + 0.5f, 0.5f)); // Y축으로 이동하는 Tween 애니메이션을 추가

        //    s.AppendInterval(0.1f); // 0.1초의 딜레이를 추가

        //    s.AppendCallback(() => sr.sprite = member.idle) // idle 스프라이트로 변경하는 콜백 애니메이션을 추가
        //        .Append(member.memberCharacter.transform.DOLocalMoveY(initPos.y, 0.5f)); // Y축으로 이동하는 Tween 애니메이션을 추가

        //    //s.SetLoops(-1, LoopType.Yoyo); // 애니메이션 시퀀스를 무한 반복하고 Yoyo 모드로 설정 (앞뒤로 반복)

        //    delay += 0.5f; // 다음 애니메이션의 시작 딜레이를 증가
        //}
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
