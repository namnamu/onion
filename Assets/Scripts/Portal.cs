using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string transferMapName; // ��⸸ �ص� ���� Portal
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
            thePlayer.preteritMapName = thePlayer.currentMapName; // ���� �� �̸� ����
            thePlayer.currentMapName = transferMapName; // ���� �� �̸� ����
            SceneManager.LoadScene(transferMapName); // ���� �� �ε�

            //ȭ�� ��ȯ�� �÷��̾� ��ġ
            P1ToTheP2();
        }
    }
    public void P1ToTheP2()
    {
        PlayerPrefs.SetFloat("Position_x", -1.16f);
        PlayerPrefs.SetFloat("Position_y", -0.55f);
        PlayerPrefs.SetString("Scene", "Play2");
    }
}
