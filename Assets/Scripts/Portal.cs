using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string transferMapName; // 닿기만 해도 가는 Portal
    private PlayerScript thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (thePlayer == null)
            thePlayer = FindObjectOfType<PlayerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            thePlayer.preteritMapName = thePlayer.currentMapName; // 이전 씬 이름 저장
            thePlayer.currentMapName = transferMapName; // 현재 씬 이름 저장
            SceneManager.LoadScene(transferMapName); // 현재 씬 로드
        }
    }
}
