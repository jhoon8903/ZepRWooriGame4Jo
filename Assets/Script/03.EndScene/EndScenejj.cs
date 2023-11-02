using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Script._03.EndScene
{
    public class EndScenejj : MonoBehaviour
    {
        // public GameObject memberCharacter;
        public Button restartBtn;
        public Button exitBtn;

        public GameObject endingCredit;
        private TextMeshProUGUI _creditText;
        public float colorChangeDuration = 1.0f;
        public Vector3 circleCenter = new Vector3(0, 0, 0);
        public float radius = 1.0f;

        private void Awake()
        {
            restartBtn.onClick.AddListener(Restart);
            exitBtn.onClick.AddListener(Exit);
            _creditText = endingCredit.GetComponent<TextMeshProUGUI>();
            circleCenter = endingCredit.transform.position;
        }

        private void Start()
        {
            /*
             * by 정훈
             * 조 이름 회전 및 컬러 변경
             */
            StartCoroutine(MoveInCircle());
            DOTween.To(() => _creditText.color, x => _creditText.color = x, new Color(Random.value, Random.value, Random.value, 1), colorChangeDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .OnStepComplete(() =>
                {
                    DOTween.To(() => _creditText.color, x => _creditText.color = x, new Color(Random.value, Random.value, Random.value, 1), colorChangeDuration);
                });
        }

        private IEnumerator MoveInCircle()
        {
            Vector3 originalPosition = circleCenter;
            float timer = 0.0f;
            float circleDuration = 5.0f;

            while (true)
            {
                float angle = timer / circleDuration * 360 * Mathf.Deg2Rad;
                Vector3 offset = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
                endingCredit.transform.position = originalPosition + offset;

                timer += Time.deltaTime;
                if (timer > circleDuration) timer -= circleDuration;

                yield return null;
            }
        }

        // Start is called before the first frame update
        // void Start()
        // {
        //     // memberCharacter.transform.DOMoveY(1, 1).SetLoops(-1, LoopType.Restart);
        //     Sequence moveSequence = DOTween.Sequence();
        //     moveSequence.Append(memberCharacter.transform.DOMoveY(1, 0.3f)); // Y ��ǥ�� 1�� �̵�
        //     moveSequence.Append(memberCharacter.transform.DOMoveY(0, 0.5f)); // Y ��ǥ�� 0���� �̵�
        //     moveSequence.AppendInterval(0.5f);
        //     moveSequence.SetLoops(-1, LoopType.Restart); // ���� ����
        // }

        public void Restart()
        {
            SceneManager.LoadScene("Game");
        }

        public void Exit()
        {
            SceneManager.LoadScene("Start");
        }
    }
}
