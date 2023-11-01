using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Script._02.GameScene
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private TextMeshProUGUI leftCountText;
        [SerializeField] private TextMeshProUGUI selectCountText;
        public int maxCount = 18;
        public int currentCount;
        public int selectScore;
        public int highScore;
        private const string ScoreKey = "Score";
        private const string CurrentScoreKey = "CurrentScore";
        
        

        private void Awake()
        {
            // GameManager SingleTon
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
            // 현재 카운트를 최대 카운트로 초기화 
            currentCount = maxCount;
            leftCountText.text = $"남은 횟수 : {currentCount:00}";
            selectScore = 0;
            selectCountText.text = $"시도 횟수 : {selectScore:00}";

        }

        private void Start()
        {
            
            CardManager.Instance.ShuffleCard();
        }

        public void UpdateText()
        {
            leftCountText.text = $"남은 횟수 : {currentCount:00}";
            selectCountText.text = $"시도 횟수 : {selectScore:00}";
        }

        public IEnumerator End()
        {
            // 카운트가 남아 있으면 리턴
            if (currentCount > 0) yield break;
        
            // 화면 종료시 터치 스코어
            int highPoint = PlayerPrefs.GetInt(ScoreKey, highScore);
        
            if (selectScore > highPoint)
            {
                PlayerPrefs.SetInt(ScoreKey, selectScore);
            }
            else
            {
                PlayerPrefs.SetInt(CurrentScoreKey, selectScore);
            }
        
            yield return new WaitForSecondsRealtime(1.0f);
            // 카운트가 0 또는 0보다 작으면 EndScene 호출
            SceneManager.LoadScene("EndScene");
        }
    }
}
