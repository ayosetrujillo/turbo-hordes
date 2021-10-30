using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Player Setting")]
    public int totalHealth = 3;
    public Animator animator;
    public bool inmunity = false;
    public SpriteRenderer spritePlayer;
    public GameObject burstHurtPlayer;
    public float knockBackForce = 1f;

    public GameObject cutTransition;


    [Header("Health UI Setting")]
    public float heartSize = 8f;
    public RectTransform heartUI;

    [SerializeField]
    private int _health;

    public Rigidbody2D rigidBody;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spritePlayer = GetComponentInChildren<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _health = totalHealth;
        heartUI.sizeDelta = new Vector2(heartSize * _health, heartSize);
    }

    public void AddDamage(int amount)
    {
        //rigidBody.AddForce(new Vector2(transform.position.x * knockBackForce, transform.position.y), ForceMode2D.Impulse);

        //knockBack 
        rigidBody.AddForce(transform.up * knockBackForce, ForceMode2D.Impulse);

        if (inmunity == false) {

            
            inmunity = true;
            _health = _health - amount;
            burstHurtPlayer.SetActive(true);
            CinemachineShake.Instance.ShakeCamera(2f, 1f);
            StartCoroutine("SetInmunity", inmunity);

            //GAME OVER
            if (_health <= 0)
            {
                _health = 0;
                inmunity = false;
                // Death Animation Corroutine
                StartCoroutine("DeathAnimation");
            }

            heartUI.sizeDelta = new Vector2(heartSize * _health, heartSize);
        }
    }

    public void AddHealth(int amount)
    {
        _health = _health + amount;

        if (_health > totalHealth)
        {
            _health = totalHealth;
            Debug.Log("PLAYER IS FULL");
        }

        heartUI.sizeDelta = new Vector2(heartSize * _health, heartSize);
        Debug.Log("PLAYER GOT LIFE " + _health);
    }

    private IEnumerator SetInmunity()
    {
        // Blink Visual Effect
        spritePlayer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spritePlayer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        spritePlayer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        spritePlayer.enabled = true;

        //Back to Idle state
        yield return new WaitForSeconds(0.5f);
        burstHurtPlayer.SetActive(false);
        inmunity = false;
    }


    private IEnumerator DeathAnimation()
    {
        cutTransition.SetActive(true);
        //Back to Idle state
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
