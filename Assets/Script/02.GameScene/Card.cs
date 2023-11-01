using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Card : MonoBehaviour
{
    public GameObject card;
    public Animator anim;
    
    void Start()
    {
        
    }

    void Update()
    {

    }
    public void OpenCard()
    {
        Debug.Log("Click");

        anim.SetBool("CardOpen", true);

        transform.Find("Front").gameObject.SetActive(true);
        transform.Find("Back").gameObject.SetActive(false);
    }

}
