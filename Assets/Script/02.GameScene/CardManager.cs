using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

/*
 * name Space 적용
 */
namespace Script._02.GameScene
{
    public class CardManager : MonoBehaviour
    {
        /*
         * by 정훈
         * 좀더 알기 쉬운 변수명으로 변경
         * Card라는 클래스가 있으므로 타입은 GameObject가 아닌 Card로 (객체지향)
         * card => cardPrefabs
         */
        public Card cardPrefab;
        public Card FirstSelectCard { get; set; }
        public Card SecondSelectCard { get; set; }

        private readonly List<Card> _cardList = new List<Card>();

        private AudioSource _shuffleSound;

        public int cardFlipCount;

        /*
         * card Instance에서 접근하기 위한 SingleTon 생성
         * first, second Card에 접근
         */
        public static CardManager Instance;

        [SerializeField] private MemberCheck memberCheck;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            _shuffleSound = GetComponent<AudioSource>();

            /*
             * by 정훈
             * 카드 생성시 발생하는 딜레이를 줄이기 위해
             * ObjetPooling 방식 사용
             */

            int[] character = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
            character = character.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();
            for (int i = 0; i < 12; i++)
            {
                /*
                 * by 정훈
                 * Prefabs를 인스턴스화 할때 Instantiate (origin GameObject, Transform transform, StayPosition bool)
                 * 속성을 사용하여 불필요한 transform 액세스 방지
                 * 직렬화를 통한 Find 메소드 ommit
                 */
                Card newCard = Instantiate(cardPrefab, transform, true);
                newCard.transform.position = transform.position;
                newCard.character.name = character[i].ToString();
                newCard.character.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(newCard.character.name);
                newCard.character.SetActive(false);
                newCard.gameObject.SetActive(false);
                _cardList.Add(newCard);
            }

           
        }

        public void ShuffleCard()
        {
            /*
             * by 정훈
             * 카드 생성시 한 지점에서 목표 지점으로 카드가 날아가는 움직임 구현
             */
            float delay = 0.2f; // 각 카드 사이의 지연 시간
            float duration = 1.5f; // 카드가 이동하는 데 걸리는 시간
            _shuffleSound.Play();
            for (int i = 0; i < _cardList.Count; i++)
            {
                Card card = _cardList[i];
                float x = (i % 4) * -1.6f + 7.7f;
                float y = (i % 3) * -2.2f + 2.7f -2f;
                Vector2 targetPosition = new Vector2(x, y);

                DOVirtual.DelayedCall(i * delay, () =>
                {
                    card.gameObject.SetActive(true);
                    card.transform.DOMove(targetPosition, duration);
                });
            }

            /*
             * by 정훈
             * 문자열 보간으로 문자열 형식 변경
             * Resources 폴더 내부의 불필요한 Sprite 삭제
             * 객체 지향을 통해 Find 메소드를 삭제하여 리소스 최적화
             * Find 메소드가 반복적으로 호출 되면 리소스 사용량에 지대한 영향을 끼침
             */
                // string charName = "character" + charactor[i];
        }
        /*
         * by 정훈
         * 함수 선언 규칙은 UpperCase
         * 해당 매치에 대한 판단 로직은 CardManager에서 해야 하지만
         * 매치 메소드의 호출을 선택이 되는 Card Class 에서 진행 되어야 함
         */
        public void IsMatched()
        {
            // string firstCardImage = firstSelectCard.transform.Find("Front").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name;
            // string secondCardImage = secondSelectCard.transform.Find("Front").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name;

            if (FirstSelectCard.character.name == SecondSelectCard.character.name)
            {
                /*
                 * by 정훈
                 * Destroy의 경우 호출시 막대한 리소스를 소모하기 때문에
                 * 해당 카드의 오브젝트를 비활성화 하는 것으로 변경
                 * 매치된 멤버의 경우 MemberCheck 클래스를 호출하여 매치 리스트 최신화
                 */
                FirstSelectCard.gameObject.SetActive(false);
                SecondSelectCard.gameObject.SetActive(false);
                memberCheck.MatchMember(FirstSelectCard.character.name);
            }
            else
            {
                FirstSelectCard.CloseCard();
                SecondSelectCard.CloseCard();
            }
        }
    }
}
