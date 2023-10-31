using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Text count;
    public GameObject Cards;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject newCard = Instantiate(Cards);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            float x = (i % 3) * -1.6f + 7.7f;
            float y = (i % 4) * -2.2f + 2.7f;
            newCard.transform.position = new Vector2(x, y);
        }
       

    }

    // Update is called once per frame
    void Update()
    {

    }

}
