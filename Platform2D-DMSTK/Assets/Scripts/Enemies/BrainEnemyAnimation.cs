using UnityEngine;

public class BrainEnemyAnimation : MonoBehaviour
{
    [Header("Settings")]
    private Animator _animator;
    private EnemyPatrol _enemyPatrol;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
    }

    void Update()
    {

        if (_enemyPatrol.patrolling == true)
        {
            _animator.SetBool("Idle", false);

        } else
        {
            _animator.SetBool("Idle", true);
            _animator.SetTrigger("Shoot");
        }

    }
}
