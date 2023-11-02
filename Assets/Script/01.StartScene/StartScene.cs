using DG.Tweening.Core.Easing;
using Script._02.GameScene;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Script._02.GameScene.MemberCheck;

namespace Script._01.StartScene
{
    public class StartScene : MonoBehaviour
    {
        public GameObject profile;
        //Start버튼
        public GameObject strBtn;
        //게임 난이도 버튼
        public GameObject easy;
        public GameObject normal;
        public GameObject hard;
        //게임 오디오
        public AudioSource audioSource;
        public AudioClip clip;

        [Serializable]
        public class Check
        {
            public Image easeCheck;
            public Image normalCheck;
            public Image hardCheck;
        }
        public List<Check> checkList = new List<Check>();

        private void Awake()
        {   //처음시작시 Normal으로 초기화
            PlayerPrefs.SetInt("Level", 20);
            PlayerPrefs.Save();
            //버튼 연결 및 버튼 함수 실행
            Button btn = strBtn.transform.GetComponent<Button>();
            Button easyBtn = easy.transform.GetComponent<Button>();
            Button normalBtn = normal.transform.GetComponent<Button>();
            Button hardBtn = hard.transform.GetComponent<Button>();
            btn.onClick.AddListener(() => {StartCoroutine(WaitForTime());}); //코루틴을 이용한 재생
            easyBtn.onClick.AddListener(() => Level(30,true,false,false));
            normalBtn.onClick.AddListener(() => Level(20, false, true, false));
            hardBtn.onClick.AddListener(() => Level(10, false, false, true));
            
            //Audio연결 및 재생
            audioSource.clip = clip;
            audioSource.Play();
            for (int i = 0; i < 6; i++)
            {
                GameObject newProfile = Instantiate(profile);
                //부모 오브젝트 지정
                newProfile.transform.parent = GameObject.FindWithTag("LoopObjcet").transform;
                float x = (i % 7) * 3.5f - 7f;
                //짝수 홀수 위치 지정
                if (i % 2 == 0)
                    newProfile.transform.position = new Vector3(x, 0.4f, 0);
                else
                    newProfile.transform.position = new Vector3(x, -0.4f, 0);
                //Prefab 자식의 Sprite에 접근하여 이미지 변경
                newProfile.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(i.ToString());
            }
        }
        private IEnumerator WaitForTime()
        {
            // 사운드 재생
            strBtn.GetComponent<AudioSource>().Play();
            // 버튼 누르고 대기 시간 지정 0.5초
            yield return new WaitForSeconds(0.3f);
            StartBtn();
        }

        // 메소드 선언은 첫 문자는 무조건 UpperCase
        private static void StartBtn()
        {
            SceneManager.LoadScene("Game");
        }
        //int값은 레벨에 따른 횟수이고  bool값은 어떤 레벨인지 표시하기
        public void Level(int levelNum,bool isEasy,bool isNormal,bool isHard)
        {
            easy.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("Level", levelNum);
            PlayerPrefs.Save();
            //리스트 안에 있는 check값들 bool 값 지정해줌
            checkList[0].easeCheck.gameObject.SetActive(isEasy);
            checkList[0].normalCheck.gameObject.SetActive(isNormal);
            checkList[0].hardCheck.gameObject.SetActive(isHard);
        }
    }
}
