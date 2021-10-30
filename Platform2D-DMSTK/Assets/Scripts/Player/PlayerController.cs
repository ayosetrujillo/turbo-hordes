using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // References
	private Rigidbody2D _rigidbody;
    private Animator _playerAnimator;

    //Jumping
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundChechRadius = 0.025f;
    public float jumpForce;
    private float _timeInAir = 0;


    // Movement
    public float speed = 2.5f;
    private float _verticaInput;
    private Vector2 _movement;
    private bool _isGrounded;
    private bool _facingRight = true;
    private bool _isRolling = false;
    private bool _isCrouching = false;


    //Attack
    private bool _isAttacking;
   

    // Shortcuts
    public Rigidbody2D RigidBody => _rigidbody;
    public bool FacingRight => _facingRight;
    public bool IsGrounded => _isGrounded;
    public bool IsAttacking => _isAttacking = false;
    public Vector2 Movement => _movement;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _isAttacking = false;
        _timeInAir = 0;
    }

    void Update()
    {
		// transformamos el input en un vector2 para poder usarlo en el rigidbody
        // GetAxisRaw es un truco para evitar pequeño retraso del GetAxis

        if(_isAttacking == false)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _movement = new Vector2(horizontalInput, 0f);

            _verticaInput = Input.GetAxisRaw("Vertical");

            //Update Facing
            if (horizontalInput < 0f && _facingRight == true)
            {
                FlipSprite();

            }
            else if (horizontalInput > 0f && _facingRight == false)
            {
                FlipSprite();
            }
        }

        // Is Grounded????????
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundChechRadius, groundLayer);

        //Debug.Log("__ en el suelo ___");

        if (_isGrounded == true)
        {
            _timeInAir = 0;

        } else {
            _timeInAir += Time.deltaTime;

        }

        // Can jumping?
        if(Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false && _isRolling == false && _isCrouching == false)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

         // Coyote Time EXCEPTION 
        if (Input.GetButtonDown("Jump") && _isGrounded == false && _isAttacking == false && _isRolling == false && _isCrouching == false && (_timeInAir < 0.18f))
        {
            if(_rigidbody.velocity.y < 1f) //evitar double jump
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //Lading Roll

        if (_timeInAir > 0.70f)
        {
            _playerAnimator.SetBool("HighFall", true);
        } else {
            _playerAnimator.SetBool("HighFall", false);
        }

        //Attack
        if (Input.GetButtonDown("Fire1") && _isAttacking == false && _isRolling == false && _isCrouching == false && _isGrounded == true)
        {            
            _isAttacking = true; // animación atacar
            _movement = Vector2.zero;  // paro al personaje
            _rigidbody.velocity = Vector2.zero;

            _playerAnimator.SetTrigger("Attack");
        }

        //Air Attack
        if (Input.GetButtonDown("Fire1") && _isAttacking == false && _isRolling == false && _isCrouching == false && _isGrounded == false)
        {
            _isAttacking = true; // animación atacar
            _playerAnimator.SetTrigger("Attack");
        }

        //Attack 3 // Second Button
        if (Input.GetButtonDown("Fire2") && _isAttacking == false && _isRolling == false && _isCrouching == false)
        {

            _isAttacking = true; // animación atacar
            _movement = Vector2.zero;  // paro al personaje
            _rigidbody.velocity = Vector2.zero;

            _playerAnimator.SetTrigger("Attack3");
        }

        //Crouch
        if ((_verticaInput < 0) && _isGrounded == true && _isAttacking == false && _isRolling == false)
        {
            _isCrouching = true; // animación atacar
            _movement = Vector2.zero;  // paro al personaje
            _rigidbody.velocity = Vector2.zero;

            _playerAnimator.SetBool("Crouch", true);
        }
        //Up
        if ((_verticaInput >= 0) && _isGrounded == true && _isAttacking == false && _isRolling == false)
        {
            _isCrouching = false; // animación atacar
            _playerAnimator.SetBool("Crouch", false);
        }
    }

    void FixedUpdate()
    {
        // en el fixedupdate es mejor asignar físicas, transformamos el movement en velocity

        if (_isCrouching == false)
        {
            float horizontalVelocity = _movement.normalized.x * speed;
            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        }
        
    }


    public void FlipSprite()
    {
        _facingRight = !_facingRight;

        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    public void AttackFinished() //Animation Event
    {
        
        _isAttacking = false; 
    }

    public void RollingStatus()
    {
        _isRolling = !_isRolling;
    }

    /*
    public void InputManager()
    {
        if(!canReceiveInput)
        {
            canReceiveInput = true;
        } else {
            canReceiveInput = false;
        }
    } */

}
