using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossumScript : MonoBehaviour
{
    Rigidbody2D rigid;
    public int head;//방향
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        head = -1;
        //Invoke("FindPlayer", 1);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(head, rigid.velocity.y);
        
        //find cliff
        Vector2 rayStart = new Vector2(rigid.position.x + head * 0.1f, rigid.position.y);//raycast거리
        Debug.DrawRay(rayStart, Vector3.left, new Color(1, 0, 0));
        RaycastHit2D cliffCheck = Physics2D.Raycast(rayStart, Vector3.down, 1 , LayerMask.GetMask("Floor"));//raycast길이
        RaycastHit2D playerCheck = Physics2D.Raycast(rayStart, Vector3.left, 1, LayerMask.GetMask("Player"));
        if (cliffCheck.collider == null)
        {
            head = (-1) * head;//반대로 돌기
        }
        if (playerCheck.collider != null)
        {
            Debug.Log("monster detected player");
            CancelInvoke();//생각하기 위해 잠시 멈췄다가 실행
            //Invoke("FindPlayer", 1);
        }

    }

    void FindPlayer()
    {
        head = -1;
        Debug.Log(head);
        Invoke("FindPlayer", Random.Range(1f, 3f));//최소<=난수<최대
    }
}
