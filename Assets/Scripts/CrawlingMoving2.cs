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
        //동서남북으로 뻗은 감지광선
        //1. 시작 위치
        Vector2 rayStart = new Vector2(rigid.position.x, rigid.position.y);
        //2. 광선 배치
        south = Physics2D.Raycast(rayStart, Vector3.down, 0.25f, LayerMask.GetMask("Floor"));
        north = Physics2D.Raycast(rayStart, Vector3.up, 0.25f, LayerMask.GetMask("Floor"));
        east = Physics2D.Raycast(rayStart, Vector3.right, 0.25f, LayerMask.GetMask("Floor"));
        west = Physics2D.Raycast(rayStart, Vector3.left, 0.25f, LayerMask.GetMask("Floor"));
        //3. 시각화
        Debug.DrawRay(rayStart, Vector3.down * 0.25f, new Color(1, 0, 0));//east
        Debug.DrawRay(rayStart, Vector3.up * 0.25f, new Color(0, 1, 0));//south
        Debug.DrawRay(rayStart, Vector3.right * 0.25f, new Color(1, 0, 1));//north
        Debug.DrawRay(rayStart, Vector3.left * 0.25f, new Color(0, 0, 1));//west

        //움직임
        rigid.velocity = forward;

        //조건 호출
        if (east==false&&west==false&&south == true && north==false)//남쪽만 있음.
        {
            if (before != "e")
            {
                time = 0;//처음 들어옴
            }
            forward = new Vector2( -speed,0);
            before = "e";//동쪽에서 왔다.
        }
        if (east == true && west == false && south == false && north == false)//동쪽만 있음.
        {
            if (before != "n")
            {
                time = 0;//처음 들어옴
            }
            forward =new Vector2(0, -speed);
            before = "n";//북쪽에서 왔다.
        }
        if (east == false && west == true && south == false && north == false)//서쪽만 있음.
        {
            if (before != "s")
            {
                time = 0;//처음 들어옴
            }
            forward =new Vector2(0,speed);
            before = "s";
        }
        if (east == false && west == false && south == false && north == true)//북쪽만 있음.
        {
            if (before != "w")
            {
                time = 0;//처음 들어옴
            }
            forward =new Vector2(speed, 0);
            before = "w";
        }
        if (east == false && west == false && south == false && north == false)//감지 없음.
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
            //광선이 끝나도 앞으로 계속 감.
            if (time > speed*2/3)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                forward = new Vector2(0, -speed);//아래로 이동함.
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
