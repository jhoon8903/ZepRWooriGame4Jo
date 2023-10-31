using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public GameObject ProfileBox; // �������� UI ����
    public GameObject ProfileImg1; // �������� UI�� ��� �̹���
    public GameObject ProfileImg2; // �������� UI�� �ϴ� �̹���
    public Text Name; // �������� UI �̸�, MBTI ��¶�
    public Text ProfileText; // �������� UI ���� ��¶�
    public TextAsset Data;

    public void Start()
    {
        string TxtLoad = Data.text.Substring(0, Data.text.Length - 1);
        ProfileText.text = TxtLoad;
    }

    public void Open()
    {
         // ī�� ��Ī�� UI�� ���µǴ��ڵ� �ʿ�
    }

    public void Close()
    {
        ProfileBox.SetActive(false); // �ݱ� ��ư Ŭ���� ������ UI �ݱ�
    }

}
