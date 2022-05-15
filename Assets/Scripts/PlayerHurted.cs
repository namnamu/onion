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
            OnDamaged(collision.transform.position);//�浹�� ��� ��ġ
            if (collision.gameObject.GetComponent<AliveObject>())
            { //���� �����ؼ� ��ģ ���
                float damage = collision.gameObject.GetComponent<AliveObject>().getAttack();
                if (damage > 0)
                {
                    hpScript.hpMinus(damage);
                }
            }
            else //��ֹ� � ���� ��ģ ���
            {
                hpScript.hpMinus(10);
            }
        }
    }

    void OnDamaged(Vector2 targetPos)
    {

        animator.SetTrigger("isDamaged");
        //������ �� �������
        movingScript.enabled = false;
        attackScript.enabled = false;

        //����
        ishurted = true;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //�˹�
        int direction = transf.position.x - targetPos.x > 0 ? 1 : -1;//�˹� ����
        transf.Translate(new Vector2(direction, 1) * knockback);//ƨ�ܳ���


        Invoke("MovingEnabled", 1);
        Invoke("OffDamaged", 2);
    }
    void MovingEnabled()
    {
        movingScript.enabled = true;
    }
    void OffDamaged()
    {
        //���� ����
        ishurted = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);

        //�ٽ� ������
        attackScript.enabled = true;
    }
}