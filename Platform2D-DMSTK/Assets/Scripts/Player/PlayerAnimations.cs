using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public float longIdleTime = 5f;

    private Animator _playerAnimator;
    private PlayerController _playerController;

    //Long Idle
    private float _longIdleTimer;

    void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    void LateUpdate()
    {
        //si está el vector en cero, estará en IDLE.
        _playerAnimator.SetBool("Idle", _playerController.Movement == Vector2.zero);
        _playerAnimator.SetBool("IsGrounded", _playerController.IsGrounded);
        _playerAnimator.SetFloat("VerticalVelocity", _playerController.RigidBody.velocity.y);

        if(_playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            _longIdleTimer += Time.deltaTime;

            if(_longIdleTimer >= longIdleTime)
            {
                _playerAnimator.SetTrigger("LongIdle");
            }

        } else {
            _longIdleTimer = 0f;
        }
    }
}
