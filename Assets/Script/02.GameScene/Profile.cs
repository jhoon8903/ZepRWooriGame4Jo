using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public GameObject ProfileBox; // 프로파일 UI 지정

    public GameObject ProfileImg1; // 프로파일 UI의 상단 이미지

    public GameObject ProfileImg2; // 프로파일 UI의 하단 이미지

    public Text Name; // 프로파일 UI 이름, MBTI 출력란

    public Text ProfileText; // 프로파일 UI 내용 출력란

    public int CardTypematch;

    private List<TeamMember> teamMembers;




    // Create a class to hold each row of data
    public class TeamMember
    {
        public int Num;
        public string Name;
        public string Mbti;
        public string Txt;
    }

    void OnEnable()
    {
        // UI가 활성화될 때 호출됩니다.
        LoadDataAndRefreshUI();
    }

    public void LoadDataAndRefreshUI()
    {
        TextAsset teamData = Resources.Load<TextAsset>("Team4DB");

        string[] data = teamData.text.Split(new char[] { '\n' });
        teamMembers = new List<TeamMember>();

        for (int i = 1; i < data.Length; i++) // Skip the first row (header)
        {
            string[] row = data[i].Split(new char[] { ',' });

            TeamMember t = new TeamMember();
            t.Num = int.Parse(row[0]);
            t.Name = row[1];
            t.Mbti = row[2];
            t.Txt = row[3];

            teamMembers.Add(t);
        }

        UpdateUI();
    }

    public void UpdateUI()
    {

        // Output the loaded data

        foreach (TeamMember member in teamMembers)
        {
            if(CardTypematch == member.Num) // CardTypematch와 같은 번호의 데이터만 출력하도록 설정
            {
               string name = "이름 : ";
               string mbtiType = "MBTI 유형 :";
               string CardImgname1 = "ProfileImg/"+member.Name + "_S"; // 가져올 스프라이트 이름 설정
               string CardImgname2 = "ProfileImg/"+member.Name; // 가져올 스프라이트 이름 설정

                Sprite loadedSprite = Resources.Load<Sprite>(CardImgname1);// CardImgname와 동일한 이름의 이미지를 가져오도록 설정
                Sprite loadedSprite2 = Resources.Load<Sprite>(CardImgname2);// CardImgname2와 동일한 이름의 이미지를 가져오도록 설정

                ProfileImg1.GetComponent<Image>().sprite = loadedSprite;
                ProfileImg2.GetComponent<Image>().sprite = loadedSprite2;
                Name.text = name + member.Name + '\n' + mbtiType + member.Mbti; // 이름 MBTI 이름 설정 지정
                ProfileText.text = member.Txt; // 텍스트 설정 지정

                Debug.Log(CardImgname2);
                Debug.Log($"Num: {member.Num}, Name: {member.Name}, Mbti: {member.Mbti}, Txt: { member.Txt}");

            }
        }
    }
    public void ProfileOpen()
    {
        ProfileBox.SetActive(true); // 닫기 버튼 클릭시 프로필 UI 닫기

    }

    public void Close()
    {
        ProfileBox.SetActive(false); // 닫기 버튼 클릭시 프로필 UI 닫기

    }

    private void Start()
    {

        ProfileBox.SetActive(false);
    }
}