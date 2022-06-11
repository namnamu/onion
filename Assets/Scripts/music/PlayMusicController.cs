using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusicController : MonoBehaviour
{
    private AudioSource BGM;
    
    //ÆÄ±« ¸·±â
    public static PlayMusicController Instance;

    private void Awake()
    {
        if (Instance != null || SceneManager.GetActiveScene().name == "Play2")
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = true;

        BGM.Play();
    }
}