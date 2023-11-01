using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * by 정훈
 * NameSpace 지정
 */
namespace Script._02.GameScene
{
    public class Profile : MonoBehaviour
    {
        public GameObject ProfileBox; // 프로파일 UI 지정

        public GameObject ProfileImg1; // 프로파일 UI의 상단 이미지

        public GameObject ProfileImg2; // 프로파일 UI의 하단 이미지

        public TextMeshProUGUI Name; // 프로파일 UI 이름, MBTI 출력란

        public TextMeshProUGUI ProfileText; // 프로파일 UI 내용 출력란

        // public int CardTypematch;

        private List<TeamMember> teamMembers;

        public Button closeBtn;




        // Create a class to hold each row of data
        public class TeamMember
        {
            public int Num;
            public string Name;
            public string Mbti;
            public string Txt;
        }

        /*
         * by 정훈
         * 패널이 열릴때 데이터를 읽어 오는 것이 아닌
         * 미리 데이터를 변수에 저장하여 해당 멤버의 데이터만 추후 패널이 활성화 되면 가지고 오는 방식이
         * 좀 더 효과적
         */

        private void Awake()
        {
            LoadDataAndRefreshUI();
            closeBtn.onClick.AddListener(Close);
        }
        // void OnEnable()
        // {
        //     // UI가 활성화될 때 호출됩니다.
        //     LoadDataAndRefreshUI();
        // }

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

            // UpdateUI();
        }

        /*
         * by 정훈
         * MemberCheck Class로 부터 매개변수룰 받아 해당하는 인원의 데이터를 불러오가
         */
        private void UpdateUI(int memberIndex)
        {

            // Output the loaded data

            foreach (TeamMember member in teamMembers)
            {
                // 매개변수로 받은 Member Index와 비교하여 데이터 비교   
                if(memberIndex == member.Num) 
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

        public void ProfileOpen(int memberIndex)
        {
            ProfileBox.SetActive(true); // 패널 활성화
            UpdateUI(memberIndex);

        }

        public void Close()
        {
            CardManager.Instance.cardFlipCount = 0;
            Debug.Log($"Count : {CardManager.Instance.cardFlipCount}");
            CardManager.Instance.FirstSelectCard = null;
            CardManager.Instance.SecondSelectCard = null;
            ProfileBox.SetActive(false); // 닫기 버튼 클릭시 프로필 UI 닫기
        }
    }
}