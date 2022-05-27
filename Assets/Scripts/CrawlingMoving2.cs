using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingMoving2 : MonoBehaviour
{
    Rigidbody2D rigid;
    float speed;
    RaycastHit2D south;
    RaycastHit2D north;
    RaycastHit2D west;
    RaycastHit2D east;
    Vector2 forward;

    string before;
    float time;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        speed = 0.5f;
        before = "e";
        time =0;
    }
    void FixedUpdate()
    {
        //������������ ���� ��������
        //1. ���� ��ġ
        Vector2 rayStart = new Vector2(rigid.position.x, rigid.position.y);
        //2. ���� ��ġ
        south = Physics2D.Raycast(rayStart, Vector3.down, 0.25f, LayerMask.GetMask("Floor"));
        north = Physics2D.Raycast(rayStart, Vector3.up, 0.25f, LayerMask.GetMask("Floor"));
        east = Physics2D.Raycast(rayStart, Vector3.right, 0.25f, LayerMask.GetMask("Floor"));
        west = Physics2D.Raycast(rayStart, Vector3.left, 0.25f, LayerMask.GetMask("Floor"));
        //3. �ð�ȭ
        Debug.DrawRay(rayStart, Vector3.down * 0.25f, new Color(1, 0, 0));//east
        Debug.DrawRay(rayStart, Vector3.up * 0.25f, new Color(0, 1, 0));//south
        Debug.DrawRay(rayStart, Vector3.right * 0.25f, new Color(1, 0, 1));//north
        Debug.DrawRay(rayStart, Vector3.left * 0.25f, new Color(0, 0, 1));//west

        //������
        rigid.velocity = forward;

        //���� ȣ��
        if (east==false&&west==false&&south == true && north==false)//���ʸ� ����.
        {
            if (before != "e")
            {
                time = 0;//ó�� ����
            }
            forward = new Vector2( -speed,0);
            before = "e";//���ʿ��� �Դ�.
        }
        if (east == true && west == false && south == false && north == false)//���ʸ� ����.
        {
            if (before != "n")
            {
                time = 0;//ó�� ����
            }
            forward =new Vector2(0, -speed);
            before = "n";//���ʿ��� �Դ�.
        }
        if (east == false && west == true && south == false && north == false)//���ʸ� ����.
        {
            if (before != "s")
            {
                time = 0;//ó�� ����
            }
            forward =new Vector2(0,speed);
            before = "s";
        }
        if (east == false && west == false && south == false && north == true)//���ʸ� ����.
        {
            if (before != "w")
            {
                time = 0;//ó�� ����
            }
            forward =new Vector2(speed, 0);
            before = "w";
        }
        if (east == false && west == false && south == false && north == false)//���� ����.
        {
            time += Time.deltaTime;
            Corner(time);
        }
        Debug.Log(east +"/"+ west + "/" + south + "/" + north + "/" + before + "||" + time);

    }
    private void Corner(float time)
    {
        if (before == "e")
        {
            //������ ������ ������ ��� ��.
            if (time > speed*2/3)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                forward = new Vector2(0, -speed);//�Ʒ��� �̵���.
            }
        }else if (before == "n")
        {
            if (time > speed * 2 / 3)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                forward = new Vector2(speed,0);
            }         
        }
        else if (before == "w")
        {
            if (time > speed * 2 / 3)
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
                forward = new Vector2(0, speed);
            }
        }
        else if (before == "s")
        {
            if (time > speed * 2 / 3)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                forward = new Vector2( -speed,0);
            }
        }
    }
}
