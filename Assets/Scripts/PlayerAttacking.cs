using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    Animator animator;
    GameObject particle;
    private bool isattack;

    void Start()
    {
        animator = GetComponent<Animator>();
        particle = transform.Find("attackParticle").gameObject;
        particle.SetActive(false);
        isattack = false;
    }

    void FixedUpdate()
    {
        if (!isattack&&Input.GetKey(KeyCode.X))//꾹누르고 있으면 계속 공격
        {
            OnAttack();
        }
    }

    void OnAttack()
    {
        animator.SetTrigger("isAttacking");
        particle.SetActive(true);
        isattack = true;

        Invoke("OffAttack", 0.4f);
    }

    void OffAttack()
    {
        particle.SetActive(false);
        isattack = false; 
    }
}
