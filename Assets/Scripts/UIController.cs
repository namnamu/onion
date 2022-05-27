using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    //싱글톤 패턴
    private static UIController instance = null;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this; //instance전역변수.
        }
        else
        {//2번 죽으면 이전 인스턴스가 담겨있을테니 삭제시킴
            Destroy(this.gameObject);
        }
    }

    public static UIController Instance
    { //다른 클래스에서 호출할 수 있도록
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // ========================싱글톤 패턴=========================

    GameObject gameOver;
    LoadScene loadScene;
    void Start()
    {
        gameOver = transform.Find("GameOver").gameObject;//자식중에 객체 찾기
        loadScene = GameObject.Find("GameManager").GetComponent<LoadScene>();//전체에서 객체찾기
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