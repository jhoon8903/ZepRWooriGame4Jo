using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public GameObject profile;
    public GameObject strBtn;
    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {   //AudioSource의 clip에 접근하여 음악 넣어주기
        audioSource.clip = clip;
        //Start문에서 한번 실행하여 계속 재생하게 만들기
        audioSource.Play();
        for (int i = 0; i < 6; i++)
        {
            GameObject newProfile = Instantiate(profile);
            //미리 생성해둔 부모 오브젝트의 자식으로 생성하기 위한 코드
            newProfile.transform.parent = GameObject.Find("LoopObjcet").transform;
            float x = (i % 7) * 3.5f - 7f;
            //짝수와 홀수 생성 위치
            if (i % 2 == 0)
                newProfile.transform.position = new Vector3(x, 0.4f, 0);
            else
                newProfile.transform.position = new Vector3(x, -0.4f, 0);

            //newProfile의 자식을 찾고 자식의 SpriteRenderer의 sprite 변경해주기
            newProfile.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(i.ToString());

        }
        //strBtn을 Button의 btn으로 연결시켜 사용
        Button btn = strBtn.transform.GetComponent<Button>();
        //AddListener(함수)를 사용하여 버튼에 함수 연결
        btn.onClick.AddListener(startBtn);
    }
    public void startBtn()
    {   //SceneManager를 이용하여 Scene 불러오기
        SceneManager.LoadScene("Game");
    }
}
