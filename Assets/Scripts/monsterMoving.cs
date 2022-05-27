using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMoving : MonoBehaviour
{
    Rigidbody2D rigid;
    public int head;//����
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        head = -1;
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(head, rigid.velocity.y);


        //������������ Ȯ��
        Vector2 rayStart = new Vector2(rigid.position.x + head * 0.1f, rigid.position.y);//raycast�Ÿ�
        Debug.DrawRay(rayStart, new Vector2(head, 0), new Color(1, 0, 0));//���� ������ �ð�ȭ
        RaycastHit2D cliffCheck = Physics2D.Raycast(rayStart, Vector3.down, 1 , LayerMask.GetMask("Floor"));//������ġ, ����, raycast����, �����ϴ� ���̾�
        RaycastHit2D wallCheck = Physics2D.Raycast(rayStart, new Vector2(head ,0), 0.1f, LayerMask.GetMask("Floor"));
        if (cliffCheck.collider == null || wallCheck.collider != null) // �ٴ��� ���ų� ���� ������
        {
            head = (-1) * head;//�ݴ�� ����
            transform.localScale = new Vector3(head * -1, 1, 1);//ĳ���Ͱ� �Ųٷ� ������.
        }

    }

}
