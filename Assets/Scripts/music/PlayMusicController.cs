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

    // Inspector ��ǥ���� ������� ���
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

        //���� �� �̺�Ʈ�� ����� �ݴϴ�.
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
    //==================�ı� ����
    public static PlayMusicController Instance;

    private void Awake()
    {
        if (Instance != null)//������� ����.
        {
            Destroy(gameObject);//������ �Ⱥ�������� ���� ������Ʈ �ı�.
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);//�ı� ��
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