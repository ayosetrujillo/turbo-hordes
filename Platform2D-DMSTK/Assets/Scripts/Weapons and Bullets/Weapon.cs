using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]

    public GameObject bulletPrefab;
    public GameObject shooter;

    private Transform _firePointPosition;

    private void Awake()
    {
        _firePointPosition = transform.Find("FirePoint");

    }

    public void Shoot()
    {
        if (bulletPrefab != null && shooter != null && _firePointPosition != null)
        {
            // disparamos
            GameObject bulletInstantiate = Instantiate(bulletPrefab, _firePointPosition.position, Quaternion.identity);

            Bullet bulletComponent = bulletInstantiate.GetComponent<Bullet>();

            if(shooter.transform.localScale.x < 0f)
            {
                bulletComponent.direction = Vector2.left;
            } else
            {
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}
