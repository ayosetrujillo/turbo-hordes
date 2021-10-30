using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Bullet Settings")]

    public int damage;
    public float bulletSpeed;
    public float bulletLivingTime = 1f;
    public Vector2 direction;

    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletLivingTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = direction.normalized * bulletSpeed;
        _rigidbody.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerHealth>().AddDamage(damage);

            collision.SendMessageUpwards("AddDamage", damage);

            Destroy(gameObject);
        }
    }
}
