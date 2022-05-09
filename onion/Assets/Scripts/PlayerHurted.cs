using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurted : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform transform;
    Animator animator;
    PlayerMoving movingScript;
    PlayerAttacking attackScript;
    AliveObject hpScript;
    public float knockback = 0.1f;
    private bool ishurted;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        movingScript = GetComponent<PlayerMoving>();
        attackScript = GetComponent<PlayerAttacking>();
        hpScript = GetComponent<AliveObject>();
        ishurted = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!ishurted && collision.gameObject.tag == "enemy")
        {
            OnDamaged(collision.transform.position);//�浹�� ��� ��ġ
            float damage = collision.gameObject.GetComponent<AliveObject>().getAttack();
            if (damage > 0)
            {
                hpScript.hpMinus(damage);
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
        int direction = transform.position.x - targetPos.x > 0 ? 1 : -1;//�˹� ����
        transform.Translate(new Vector2(direction, 1) * knockback);//ƨ�ܳ���



        Invoke("OffDamaged", 2);
    }

    void OffDamaged()
    {
        //���� ����
        ishurted = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);

        //�ٽ� ������
        movingScript.enabled = true;
        attackScript.enabled = true;
    }
}