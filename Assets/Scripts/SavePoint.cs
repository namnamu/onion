using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SavePoint : MonoBehaviour
{
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        //위치
        if (PlayerPrefs.HasKey("Position_x") && PlayerPrefs.HasKey("Position_y"))
        {
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("Position_x"), PlayerPrefs.GetFloat("Position_y"));
        }
        else
        {
            player.transform.position = new Vector2(-1.6f, -0.053f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("저장");
            PlayerPrefs.SetFloat("Position_x", transform.position.x);
            PlayerPrefs.SetFloat("Position_y", transform.position.y);
            Debug.Log("전 씬:" + PlayerPrefs.GetString("Scene"));
            PlayerPrefs.SetString("Scene", this.gameObject.scene.name);
            Debug.Log("저장된 씬:" + PlayerPrefs.GetString("Scene"));
        }
    }
    //예외. 씬전환
    public void P1ToTheP2()
    {
        PlayerPrefs.SetFloat("Position_x", -1.16f);
        PlayerPrefs.SetFloat("Position_y", 1.06f);
    }
    public void P2ToTheP1()
    {
        PlayerPrefs.SetFloat("Position_x", 1.56f);
        PlayerPrefs.SetFloat("Position_y", 0.51f);

    }
}
