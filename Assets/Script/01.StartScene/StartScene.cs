using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script._01.StartScene
{
    public class StartScene : MonoBehaviour
    {
        public GameObject profile;
        public GameObject strBtn;
        public AudioSource audioSource;
        public AudioClip clip;
        private void Awake()
        {
            //strBtn�� Button�� btn���� ������� ���
            Button btn = strBtn.transform.GetComponent<Button>();
            //AddListener(�Լ�)�� ����Ͽ� ��ư�� �Լ� ����
            btn.onClick.AddListener(() =>
            {
                // by 정훈
                // Start 버튼 클릭시 사운드 재생을 위해 코루틴 호출
                StartCoroutine(WaitForTime());
            });
            //AudioSource�� clip�� �����Ͽ� ���� �־��ֱ�
            audioSource.clip = clip;
            //Start������ �ѹ� �����Ͽ� ��� ����ϰ� �����
            audioSource.Play();
            for (int i = 0; i < 6; i++)
            {
                GameObject newProfile = Instantiate(profile);
                //�̸� �����ص� �θ� ������Ʈ�� �ڽ����� �����ϱ� ���� �ڵ�
                newProfile.transform.parent = GameObject.FindWithTag("LoopObjcet").transform;
                float x = (i % 7) * 3.5f - 7f;
                //¦���� Ȧ�� ���� ��ġ
                if (i % 2 == 0)
                    newProfile.transform.position = new Vector3(x, 0.4f, 0);
                else
                    newProfile.transform.position = new Vector3(x, -0.4f, 0);

                //newProfile�� �ڽ��� ã�� �ڽ��� SpriteRenderer�� sprite �������ֱ�
                newProfile.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(i.ToString());

            }
        }

        private IEnumerator WaitForTime()
        {
            // by 정훈
            // 사운드 재생
            strBtn.GetComponent<AudioSource>().Play();
            // 버튼 누르고 대기 시간 지정 0.5초
            yield return new WaitForSeconds(0.3f);
            StartBtn();
        }

        // by 정훈
        // 메소드 선언은 첫 문자는 무조건 UpperCase
        private static void StartBtn()
        {
            //SceneManager�� �̿��Ͽ� Scene �ҷ����
            SceneManager.LoadScene("Game");
        }
    }
}
