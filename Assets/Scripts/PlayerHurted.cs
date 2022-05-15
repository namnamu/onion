using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurted : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform transf;
    Animator animator;
    PlayerScript movingScript;
    PlayerAttacking attackScript;
    AliveObject hpScript;
    public float knockback = 0.1f;
    private bool ishurted;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transf = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        movingScript = GetComponent<PlayerScript>();
        attackScript = GetComponent<PlayerAttacking>();
        hpScript = GetComponent<AliveObject>();
        ishurted = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!ishurted && collision.gameObject.tag == "enemy")
        {
            OnDamaged(collision.transform.position);//충돌한 상대 위치
            if (collision.gameObject.GetComponent<AliveObject>())
            { //적이 공격해서 디친 경우
                float damage = collision.gameObject.GetComponent<AliveObject>().getAttack();
                if (damage > 0)
                {
                    hpScript.hpMinus(damage);
                }
            }
            else //장애물 등에 의해 다친 경우
            {
                hpScript.hpMinus(10);
            }
        }
    }

    void OnDamaged(Vector2 targetPos)
    {

        animator.SetTrigger("isDamaged");
        //움직일 수 없어야함
        movingScript.enabled = false;
        attackScript.enabled = false;

        //무적
        ishurted = true;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //넉백
        int direction = transf.position.x - targetPos.x > 0 ? 1 : -1;//넉백 방향
        transf.Translate(new Vector2(direction, 1) * knockback);//튕겨나감


        Invoke("MovingEnabled", 1);
        Invoke("OffDamaged", 2);
    }
    void MovingEnabled()
    {
        movingScript.enabled = true;
    }
    void OffDamaged()
    {
        //무적 해제
        ishurted = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);

        //다시 움직임
        attackScript.enabled = true;
    }
}