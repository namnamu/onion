using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveObject : MonoBehaviour
{
    private string ObjName;
    private float hp;
    private float attack;
    private void Awake()
    {
        ObjName = this.gameObject.name;
        Debug.Log("ObjName:" + ObjName);
    }
    private void Start()
    {
        if (ObjName == "Player")
        {
            hp = 100;
            attack = 50;
        }
        else
        {
            hp = 100;
            attack = 40;
        }
    }
    public void hpMinus(float damage)
    {
        hp -= damage;
        Debug.Log(ObjName + "'s hp:" + hp);
    }
 
    public void hpPlus(float degree)
    {
        hp += degree;
    }

    public float getAttack()
    {
        return attack;
    }

    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            if (ObjName == "Player")
            {
                Debug.Log("게임오버");
            }
        }
    }
}
