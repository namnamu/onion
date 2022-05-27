using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    LoadScene loadScene;
    void Start()
    {
        gameOver = transform.Find("GameOver").gameObject;//�ڽ��߿� ��ü ã��
        loadScene = GameObject.Find("GameManager").GetComponent<LoadScene>();//��ü���� ��üã��
    }

    public void OnGameOver()
    {
        gameOver.SetActive(true);
        Invoke("Reroad", 3f); 
    }
    void Reroad() { 
        loadScene.Reroad();
    }

  
}