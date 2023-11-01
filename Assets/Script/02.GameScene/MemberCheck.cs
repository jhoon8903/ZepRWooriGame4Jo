using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberCheck : MonoBehaviour
{
    // nameCheck0 : 정선교
    // nameCheck1 : 박정혁
    // nameCheck2 : 선건우
    // nameCheck3 : 나재민
    // nameCheck4 : 이정훈
    // nameCheck5 : 장지후
    public GameObject[] name = new GameObject[6];
    public bool[] nameCheck = new bool[6];

    void Start()
    {

    }

    void Update()
    {
        // 카드가 알맞게 뒤집혔다면
        for (int i = 0; i < 6; i++)
        {
            if (nameCheck[i] == true)
            {

                name[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 200 / 255f);

            }
        }    
    }
}
