using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHurted : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform transform;
    //Animator animator;
    monsterMoving movingScript;
    public float knockback = 0.1f;
    private bool ishurted;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        //animator = GetComponent<Animator>();
        movingScript = GetComponent<monsterMoving>();
        ishurted = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ishurted && collision.gameObject.tag == "playerAttack")
        {
            Debug.Log("conflict!!");
            OnDamaged(collision.transform.position);//충돌한 상대 위치
        }
    }

    void OnDamaged(Vector2 targetPos)
    {

        //animator.SetTrigger("isDamaged");
        //움직일 수 없어야함
        movingScript.enabled = false;

        //무적
        ishurted = true;
        spriteRenderer.color = new Color(1, 0, 0, 0.4f);

        //넉백
        int direction = transform.position.x - targetPos.x > 0 ? 1 : -1;//넉백 방향
        transform.Translate(new Vector2(direction, 1) * knockback);//튕겨나감



        Invoke("OffDamaged", 2);
    }

    void OffDamaged()
    {
        //무적 해제
        ishurted = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);

        //다시 움직임
        movingScript.enabled = true;
    }
}
