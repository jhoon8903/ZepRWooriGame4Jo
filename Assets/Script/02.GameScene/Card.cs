using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Script._02.GameScene
{
    public class Card : MonoBehaviour
    {
        public Animator anim;

        /*
         * by 정훈
         * Card class의 객체 생성
         * Card Manager 참조
         */
        public GameObject card;
        public Sprite backSprite;
        public Sprite frontSprite;
        public GameObject character;
        private AudioSource _flipSound;
        /*
         * 빠르게 선택시 카드가 중복되는 버그를 방지 하기위한 안정장치 설정
         */
        private const float MinClickSpeed = 0.5f;
        private float _lastClick = 0f;
        private bool _isFliping;

        private void Awake()
        {
            _flipSound = GetComponent<AudioSource>();
        }

        void Update()
        {
            // 카운트 '0'되면 즉시 게임 종료
            if (GameManager.Instance.currentCount <= 0)
            {
                StartCoroutine(GameManager.Instance.End());
            }

            if (Input.GetMouseButtonDown(0)) // left mouse button
            {
                if (Time.time - _lastClick < MinClickSpeed)
                {
                    return;
                }

                _lastClick = Time.time;

                if (CardManager.Instance.cardFlipCount >=2) return;
                Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

                // if(hit.transform != null)
                // {
                //     Debug.Log("Hit Object: " + hit.transform.name); // Log the name of the object hit by the raycast
                //     Debug.Log($"Count ; {CardManager.Instance.cardFlipCount}");
                // }
                // else
                // {
                //     Debug.Log("No hit");
                //     Debug.Log($"Count ; {CardManager.Instance.cardFlipCount}");
                // }

                /*
                 * by 정훈
                 * 같은 카드를 두변 연속으로 클릭하면 같은 카드로 인식해 매치가 진행되는 버그 해결
                 */
                
                if (CardManager.Instance.SecondSelectCard == null)
                {
                    Debug.Log("1");
                    if (hit.transform != null && gameObject != null)
                    {    
                        Debug.Log("2");
                        if (hit.transform.gameObject == gameObject)
                        {
                            Debug.Log("3");
                            // 첫 번째 선택한 카드와 두 번째 선택한 카드가 같은지 확인
                            if (CardManager.Instance.FirstSelectCard != null && 
                                CardManager.Instance.FirstSelectCard == this)
                            {
                                Debug.Log("4");
                                // 같은 카드를 두 번 클릭했으므로 무시
                                return;
                            }
                            // 카드를 열고 처리
                            OpenCard(this);
                        }
                    }
                }
            }
        }



        private void OpenCard(Card selectCard)
        {
            if (CardManager.Instance.isShuffling) return;
            if (_isFliping)return;

            _isFliping = true;
            
            // Debug.Log("OpenCard");
            CardManager.Instance.cardFlipCount++;
            /*
             * by 정훈
             * 현재 카운트가 0 이하이면 EndScene으로 이동
             */
            // anim.SetBool("CardOpen", true);
                /*
                 * by 정훈
                 * 스크립트에서 해당 오브젝트를 미리 할당하여 Find 메소드로 인한 리소스 소모 최적화
                 * DOTween을 이용한 Card Flip 효과 구현
                 */

            // 카드 초기화
            card.GetComponent<SpriteRenderer>().sprite = backSprite;
            
            // 카드 Flip
            _flipSound.Play();
            float duration = 0.7f;
            transform.DORotate(new Vector3(0, 180, 0), duration)
                .SetEase(Ease.Linear)
                .OnUpdate(() =>
                {
                    if (transform.rotation.eulerAngles.y >= 90)
                    {
                        card.GetComponent<SpriteRenderer>().sprite = frontSprite;
                        character.SetActive(true);
                    }
                }).OnComplete(() =>
                {
                    if (CardManager.Instance.FirstSelectCard == null)
                    {
                        CardManager.Instance.FirstSelectCard = selectCard;
                    }
                    else if (CardManager.Instance.FirstSelectCard != null && CardManager.Instance.SecondSelectCard == null)
                    {
                        CardManager.Instance.SecondSelectCard = selectCard;
                        GameManager.Instance.selectScore++;
                        GameManager.Instance.currentCount--;
                        GameManager.Instance.UpdateText();
                        StartCoroutine(DelayedIsMatched());
                        
                        //if (GameManager.Instance.currentCount <= 0)
                        //{
                        //    StartCoroutine(GameManager.Instance.End());
                        //}
                        //Updata 부분으로 이동 by 정선교
                        
                    }
                    _isFliping = false;
                });
         
        }


        private IEnumerator DelayedIsMatched()
        {
            /*
             * by 정훈
             * 매치 확인 시 매치가 되면 카드가 바로 없어지는 것 처럼 보여 0.3초간의 텀을 주고 확인
             */
            yield return new WaitForSecondsRealtime(0.3f);
            CardManager.Instance.IsMatched();
        }

        // public void destroyCard()
        // {
        //     Invoke("destroyCardInvoke", 1.0f);
        // }
        //
        // void destroyCardInvoke()
        // {
        //     Destroy(gameObject);
        // }

        /*
         * by 정훈 
         * 함수 선언 규칙 UpperCase
         */
        public void CloseCard()
        {
            Invoke(nameof(CloseCardInvoke), 1.0f);
        }

        private void CloseCardInvoke()
        {
            // anim.SetBool("CardOpen", false);
            /*
             * by 정훈
             * Find 메소드 최적화
             */
            float duration = 0.3f;
            _flipSound.Play();
            transform.DORotate(new Vector3(0, 0, 0), duration).SetEase(Ease.Linear).OnUpdate(() =>
                {
                    if (transform.rotation.eulerAngles.y <= 90)
                    {
                        card.GetComponent<SpriteRenderer>().sprite = backSprite;
                        character.SetActive(false);
                    }
                }).OnComplete(() =>
            {
                CardManager.Instance.FirstSelectCard = null;
                CardManager.Instance.SecondSelectCard = null;
                CardManager.Instance.cardFlipCount--;
                Debug.Log($"Count : {CardManager.Instance.cardFlipCount}");
            });

            // transform.Find("Back").gameObject.SetActive(true);
            // transform.Find("Front").gameObject.SetActive(false);
            
            // backCard.SetActive(true);
            // frontCard.SetActive(false);
            // _cardFlipingCount = 0;
        }

    }
}
