using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int DamageAttack1 = 1;
    public int DamageAttack2 = 2;
    private bool _isAttacking;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        } else
        {
            _isAttacking = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isAttacking == true)
        {
            if(collision.CompareTag("Enemy"))
            {
                Debug.Log("" + collision);
                collision.SendMessageUpwards("AddDamage", DamageAttack1);
                
            }
        }
    }
}
