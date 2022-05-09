using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveObject : MonoBehaviour
{
    private string name;
    private float hp;
    private float attack;
    private void Awake()
    {
        name = this.gameObject.name;
        Debug.Log("name:" + name);
    }
    private void Start()
    {
        if (name == "player")
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
        Debug.Log(name + "'s hp:" + hp);
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
            if (name == "player")
            {
                Debug.Log("게임오버");
            }
        }
    }
}
