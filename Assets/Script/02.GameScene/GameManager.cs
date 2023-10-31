using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script._02.GameScene
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Card cardManager;
        public static GameManager Instance;
        public int maxCount;
        public int currentCount;
        public int touchScore;
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
        }

        private void Start()
        {
            cardManager.ShuffleCard();
        }

        private void End()
        {
            // 카운트가 남아 있으면 리턴
            if (currentCount > 0) return;

            // 화면 종료시 터치 스코어
            int highPoint = PlayerPrefs.GetInt(ScoreKey, highScore);

            if (touchScore > highPoint)
            {
                PlayerPrefs.SetInt(ScoreKey, touchScore);
            }
            else
            {
                PlayerPrefs.SetInt(CurrentScoreKey, touchScore);
            }

            // 카운트가 0 또는 0보다 작으면 EndScene 호출
            SceneManager.LoadScene("EndScene");
        }
    }
}
