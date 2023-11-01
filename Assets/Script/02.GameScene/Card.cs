using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Script._02.GameScene;
using DG.Tweening.Core.Easing;

public class Card : MonoBehaviour
{
    public Animator anim;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse button
        {
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            // Debug.Log($"hit Object : {hit.transform.gameObject}");
            // Debug.Log($"gameObject: {gameObject}");

            if (hit.transform != null && gameObject != null)
            {
                if (hit.transform.gameObject == gameObject)
                {
                    Debug.Log("You clicked on: " + hit.transform.name); 
                    OpenCard();
                }
            }
            else
            {
                Debug.Log("Null Area");
            }
    
        }
    }


    public void OpenCard()
    {
        anim.SetBool("CardOpen", true);
        transform.Find("Front").gameObject.SetActive(true);
        transform.Find("Back").gameObject.SetActive(false);

        if (CardManager.I.firstCard == null)
        {
            CardManager.I.firstCard = gameObject;
        }
        else
        {
            CardManager.I.secondCard = gameObject;
            CardManager.I.isMatched();
        }
    }
    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 1.0f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("CardOpen", false);
        transform.Find("Back").gameObject.SetActive(true);
        transform.Find("Front").gameObject.SetActive(false);
    }

}
