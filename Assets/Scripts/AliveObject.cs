using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AliveObject : MonoBehaviour
{//모든 오브젝트의 체력을 관리하는 스크립트로 모든 생물에 대입합니다.
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
        if (ObjName == "Player") //플레이어 체력과 공격력 설정
        {
            hp = 100;
            attack = 50;
        }
        else //몬스터 체력과 공격력 설정
        {
            hp = 100;
            attack = 40;
        }

    }

    //체력이 감소하는 경우, hp감소를 여러 스크립트에서 중복호출 되는 것을 방지하기 위한 함수
    public void hpMinus(float damage)
    {
        hp -= damage;
        Debug.Log(ObjName + "'s hp:" + hp);
    }
    //체력이 회복하는 경우, hp감소를 여러 스크립트에서 중복호출 되는 것을 방지하기 위한 함수
    public void hpPlus(float degree)
    {
        hp += degree;
    }
    // 공격력을 다른 스크립트에서 변경할 수 없도록 private로 설정해두고, 값을 읽어올 수 있게만 만든 함수
    public float getAttack() 
    {
        return attack;
    }

    private void FixedUpdate()
    {
        if (hp <= 0) //모든 생물은 체력이 0이하로 떨어지면 파괴됨.
        {
            Destroy(gameObject);
            if (ObjName == "Player")//플레이어의 경우 게임 오버의 화면이 필요함.
            {
                Debug.Log("게임오버");
                UIController.Instance.OnGameOver();
            }
            else
            { // get score
                Debug.Log("점수획득");
                ScoreUpdate.scoreValue += 10;
            }
        }
    }
}
