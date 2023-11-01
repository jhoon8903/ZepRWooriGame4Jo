using Script._02.GameScene;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;

    public static CardManager I;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        int[] charactor = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };   //
        charactor = charactor.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 12; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("CardManager").transform;

            float x = (i % 3) * -1.6f + 7.7f;
            float y = (i % 4) * -2.2f + 2.7f;
            newCard.transform.position = new Vector2(x, y);

            string charName = "charactor" + charactor[i].ToString();

            newCard.transform.Find("Front").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(charName);
        }

    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("Front").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<Card>().destroyCard();
            secondCard.GetComponent<Card>().destroyCard();
        }
        else
        {
            firstCard.GetComponent<Card>().closeCard();
            secondCard.GetComponent<Card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }


}
