using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public GameObject ProfileBox; // 프로파일 UI 지정

    public GameObject ProfileImg1; // 프로파일 UI의 상단 이미지

    public GameObject ProfileImg2; // 프로파일 UI의 하단 이미지

    public Text Name; // 프로파일 UI 이름, MBTI 출력란

    public Text ProfileText; // 프로파일 UI 내용 출력란

    public void Close()

    {

        ProfileBox.SetActive(false); // 닫기 버튼 클릭시 프로필 UI 닫기

    }
}
