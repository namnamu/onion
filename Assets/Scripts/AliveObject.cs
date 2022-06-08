using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AliveObject : MonoBehaviour
{//��� ������Ʈ�� ü���� �����ϴ� ��ũ��Ʈ�� ��� ������ �����մϴ�.
    private string ObjName;
    private float hp;
    private float attack;
    public int score;

    private void Awake()
    {
        ObjName = this.gameObject.name;
    }
    private void Start()
    {
        if (ObjName == "Player") //�÷��̾� ü�°� ���ݷ� ����
        {
            hp = 100;
            attack = 50;
        }
        else //���� ü�°� ���ݷ� ����
        {
            hp = 100;
            attack = 40;
        }

    }

    //ü���� �����ϴ� ���, hp���Ҹ� ���� ��ũ��Ʈ���� �ߺ�ȣ�� �Ǵ� ���� �����ϱ� ���� �Լ�
    public void hpMinus(float damage)
    {
        hp -= damage;
        Debug.Log(ObjName + "'s hp:" + hp);
    }
    //ü���� ȸ���ϴ� ���, hp���Ҹ� ���� ��ũ��Ʈ���� �ߺ�ȣ�� �Ǵ� ���� �����ϱ� ���� �Լ�
    public void hpPlus(float degree)
    {
        hp += degree;
    }
    // ���ݷ��� �ٸ� ��ũ��Ʈ���� ������ �� ������ private�� �����صΰ�, ���� �о�� �� �ְԸ� ���� �Լ�
    public float getAttack() 
    {
        return attack;
    }

    private void FixedUpdate()
    {
        if (hp <= 0) //��� ������ ü���� 0���Ϸ� �������� �ı���.
        {
            Destroy(gameObject);
            if (ObjName == "Player")//�÷��̾��� ��� ���� ������ ȭ���� �ʿ���.
            {
                Debug.Log("���ӿ���");
                UIController.Instance.OnGameOver();
            }
            else
            { // get score
                Debug.Log("����ȹ��");
                ScoreUpdate.scoreValue += 10;
            }
        }
    }
}
