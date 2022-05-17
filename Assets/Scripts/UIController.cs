using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //�̱��� ����
    private static UIController instance = null;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this; //instance��������.
        }
        else
        {//2�� ������ ���� �ν��Ͻ��� ��������״� ������Ŵ
            Destroy(this.gameObject);
        }
    }

    public static UIController Instance
    { //�ٸ� Ŭ�������� ȣ���� �� �ֵ���
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // ========================�̱��� ����=========================

    GameObject gameOver;
    void Start()
    {
        gameOver = transform.Find("GameOver").gameObject;
    }

    public void OnGameOver()
    {
        gameOver.SetActive(true);
        //���ε� �߰� �ʿ�
    }

}