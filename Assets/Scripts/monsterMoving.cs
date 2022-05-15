using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMoving : MonoBehaviour
{
    Rigidbody2D rigid;
    public int head;//방향
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        head = -1;
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(head, rigid.velocity.y);


        //낭떠러지인지 확인
        Vector2 rayStart = new Vector2(rigid.position.x + head * 0.1f, rigid.position.y);//raycast거리
        Debug.DrawRay(rayStart, new Vector2(head, 0), new Color(1, 0, 0));//빨간 선으로 시각화
        RaycastHit2D cliffCheck = Physics2D.Raycast(rayStart, Vector3.down, 1 , LayerMask.GetMask("Floor"));//시작위치, 방향, raycast길이, 감지하는 레이어
        RaycastHit2D wallCheck = Physics2D.Raycast(rayStart, new Vector2(head ,0), 0.1f, LayerMask.GetMask("Floor"));
        if (cliffCheck.collider == null || wallCheck.collider != null) // 바닥이 없거나 벽이 있으면
        {
            head = (-1) * head;//반대로 돌기
            transform.localScale = new Vector3(head * -1, 1, 1);//캐릭터가 거꾸로 생겼음.
        }

    }

}
