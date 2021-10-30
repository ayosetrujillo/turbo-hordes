using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    [Header("Trap Settings")]

    public int damage;
    public float time;
    public float delay;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        InvokeRepeating("Attack", time, Random.Range(delay-2, delay+2));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessageUpwards("AddDamage", damage);
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}

