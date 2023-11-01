using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberCheck : MonoBehaviour
{
    public GameObject[] namePanel = new GameObject[6];

    // 같은 카드가 뒤집히면, 이름에 표시
    public void CharactorActive(string name)
    {
        // nameCheck0 : 정선교
        // nameCheck1 : 박정혁
        // nameCheck2 : 선건우
        // nameCheck3 : 나재민
        // nameCheck4 : 이정훈
        // nameCheck5 : 장지후
        switch (name)
        {
            case "charactor0": // 정선교
                namePanel[0].gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 200 / 255f);
                break;

            case "charactor1": // 나재민
                namePanel[3].gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 200 / 255f);
                break;

            case "charactor2": // 박정혁
                namePanel[1].gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 200 / 255f);
                break;

            case "charactor3": // 선건우
                namePanel[2].gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 200 / 255f);
                break;

            case "charactor4": // 이정훈
                namePanel[4].gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 200 / 255f);
                break;

            case "charactor5": // 장지후
                namePanel[5].gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 200 / 255f);
                break;

            default:
                break;
        }


    }
}
