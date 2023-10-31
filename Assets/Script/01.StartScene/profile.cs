using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profile : MonoBehaviour
{
    [SerializeField]
    private float xSpeed;
    [SerializeField]
    private float ySpeed;
    // Start is called before the first frame update
    void Update()
    {   //Profile이 화면 밖으로 넘어가면 위치 변경
        if (transform.position.x < -10.5)
        {   //y좌표를 현재 y좌표로 받아 움직임 이어지게 
            transform.position = new Vector3(10.5f, transform.position.y, 0);
        }
    }
    private void FixedUpdate()
    {   //0.41f보다 커지면 ySpeed를 -로 작아지면 -를 곱해 +로 전환
        if (transform.position.y >= 0.41f)
            ySpeed *= -1;
        else if (transform.position.y <= -0.41f)
            ySpeed *= -1;
        transform.position += new Vector3(xSpeed, ySpeed, 0);
    }
}
