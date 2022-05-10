using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHurted : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform transf;
    //Animator animator;
    monsterMoving movingScript;
    AliveObject hpScript;
    public float knockback = 0.1f;
    private bool ishurted;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transf = GetComponent<Transform>();
        //animator = GetComponent<Animator>();
        movingScript = GetComponent<monsterMoving>();
        hpScript = GetComponent<AliveObject>();
        ishurted = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ishurted && collision.gameObject.tag == "playerAttack")
        {
            OnDamaged(collision.transform.position);//�浹�� ��� ��ġ
            float damage = GameObject.Find("Player").GetComponent<AliveObject>().getAttack();
            if (damage > 0)
            {
                hpScript.hpMinus(damage);
            }
        }
    }

    void OnDamaged(Vector2 targetPos)
    {

        //animator.SetTrigger("isDamaged");
        //������ �� �������
        movingScript.enabled = false;

        //����
        ishurted = true;
        spriteRenderer.color = new Color(1, 0, 0, 0.4f);

        //�˹�
        int direction = transf.position.x - targetPos.x > 0 ? 1 : -1;//�˹� ����
        transf.Translate(new Vector2(direction, 1) * knockback);//ƨ�ܳ���



        Invoke("OffDamaged", 2);
    }

    void OffDamaged()
    {
        //���� ����
        ishurted = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);

        //�ٽ� ������
        movingScript.enabled = true;
    }
}
