using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Card : MonoBehaviour
{
    public Text count;
    public GameObject Cards;
    public Animator anim;
    
    void Start()
    {
        int[] charactor = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };   //
        charactor = charactor.OrderBy(item => Random.Range(-1.0f,1.0f)).ToArray();

        for (int i = 0; i < 12; i++)
        {   
            GameObject newCard = Instantiate(Cards);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            float x = (i % 3) * -1.6f + 7.7f;
            float y = (i % 4) * -2.2f + 2.7f;
            newCard.transform.position = new Vector2(x, y);

            string charName = "charactor" + charactor[i].ToString();
            
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(charName);
        }
    }

    void Update()
    {

    }
    public void OpenCard()
    {
        anim.SetBool("CardOpen", true);

        transform.Find("Front").gameObject.SetActive(true);
        transform.Find("Back").gameObject.SetActive(false);
    }

}
