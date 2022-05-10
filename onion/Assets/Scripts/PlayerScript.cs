using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigid2D;

    public float walkForce = 1.0f;
    public float jumpForce = 5.0f;
    public float maxWalkSpeed = 2.0f;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    //������ �������� ȣ���ϴ� �޼���
    void Update()
    {
        // jump�ϸ鼭 key ���� �� �ְ� �ٲٱ�...
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
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
    }
}