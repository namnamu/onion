using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public string currentMapName; // 현재 플레이어가 위치한 씬 이름 저장
    public string preteritMapName; // 과거 플레이어가 위치한 씬 이름 저장
    public string[] ButtontransferMapName; // up키 눌러야 가는 씬

    Rigidbody2D rigid2D;

    public float walkForce = 1.0f;
    public float jumpForce = 5.0f;
    public float maxWalkSpeed = 2.0f;

    private bool isJumping;
    private bool isPortal;

    public static PlayerScript Instance;

    #region singleton
    private void Awake()
    {
        if (Instance != null) // 존재하면 파괴
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 플레이어 파괴방지
    }
    #endregion singleton

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        isJumping = false;
        isPortal = false;
    }

    //일정한 간격으로 호출하는 메서드
    void Update()
    {
        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            isJumping = true;
        }

        // right & left
        int key = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }

        //  up
        if (Input.GetKeyDown(KeyCode.UpArrow) && isPortal == true)
        {
            if (SceneManager.GetActiveScene().name == "Play1")
            { // Play1일 때 윗키 누르는 포탈
                preteritMapName = currentMapName;
                currentMapName = ButtontransferMapName[0]; // Store
                SceneManager.LoadScene(ButtontransferMapName[0]);

                isPortal = false;
            }
            if (SceneManager.GetActiveScene().name == "Store")
            {
                preteritMapName = currentMapName;
                currentMapName = ButtontransferMapName[1]; // Play1
                SceneManager.LoadScene(ButtontransferMapName[1]);

                //포탈없음?
                isPortal = false;
            }
            if (SceneManager.GetActiveScene().name == "Play2")
            {
                preteritMapName = currentMapName;
                currentMapName = ButtontransferMapName[1]; // Play1
                SceneManager.LoadScene(ButtontransferMapName[1]);

                isPortal = false;
                //화면 전환시 플레이어 위치
                PlayerPrefs.SetFloat("Position_x", 1.56f);
                PlayerPrefs.SetFloat("Position_y", 0.45f);
            }
        }

        // player speed
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // speed max
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // move
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Clear"))
        { // Clear Portal
            SceneManager.LoadScene("GameClear");
        }

        if (collision.gameObject.CompareTag("Portal"))
        { // Portal에 닿았을 때
            Debug.Log("Portal");
            isPortal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            isPortal = false;
        }
    }

    // 씬 전환 시 현재 씬 이름 저장
    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        currentMapName = scene.name;
    }

    void OnDisable()
    {
        // 델리게이트 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}