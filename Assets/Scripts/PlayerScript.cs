using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigid2D;

    public float walkForce = 1.0f;
    public float jumpForce = 5.0f;
    public float maxWalkSpeed = 2.0f;

    private bool isJumping;
    GameObject portal;
    GameObject store;
    GameObject player;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        isJumping = false;
        store = GameObject.FindWithTag("Portal");
        player = GameObject.Find("Player");
        portal = GameObject.FindWithTag("Portal2");
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
                
        // store
        if (Input.GetKeyDown(KeyCode.UpArrow) && (store.transform.position.x - 0.5 <= player.transform.position.x) && (store.transform.position.x + 0.5 >= player.transform.position.x))
        {
            if(SceneManager.GetActiveScene().name == "Play1")
            {
                SceneManager.LoadScene("Store");
            } else if(SceneManager.GetActiveScene().name == "Store")
            {
                SceneManager.LoadScene("Play1");
                // 집앞으로 보내기
                
            } else if (SceneManager.GetActiveScene().name == "Play2")
            {
                SceneManager.LoadScene("Play1");
            }
        }

        // portal
        if (SceneManager.GetActiveScene().name == "Play1")
        {
            if ((portal.transform.position.x - 0.5 <= player.transform.position.x) && (portal.transform.position.x + 0.5 >= player.transform.position.x) && (portal.transform.position.y + 0.5 >= player.transform.position.y))
            {
                SceneManager.LoadScene("Play2");
            }
        }
            
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
}