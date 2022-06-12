using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusicController : MonoBehaviour
{
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    // Inspector 에표시할 배경음악 목록
    public BgmType[] BGMList;

    private AudioSource BGM;
    private string NowBGMname = "";

    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = true;
        if (SceneManager.GetActiveScene().name.Equals("Play2"))
        {
            PlayBGM(BGMList[1].name);
        }
        else
        {
            PlayBGM(BGMList[0].name);
        }

        //시작 시 이벤트를 등록해 줍니다.
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;

        for (int i = 0; i < BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
                NowBGMname = name;
            }

    }
    //==================파괴 막기
    public static PlayMusicController Instance;

    private void Awake()
    {
        if (Instance != null)//비어있지 않음.
        {
            Destroy(gameObject);//이전게 안비어있으면 현재 오브젝트 파괴.
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);//파괴 ㄴ
    }
    //===============================
    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        if(scene.name.Equals("Play2"))
        {
            BGM.Stop();
            PlayBGM("play2");
        }
        else
        {
            if (!NowBGMname.Equals("play1"))
            {
                BGM.Stop();
                PlayBGM("play1");
            }

        }
    }

}