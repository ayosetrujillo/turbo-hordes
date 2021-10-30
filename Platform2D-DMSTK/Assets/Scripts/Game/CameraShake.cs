using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    Vector3 startPos;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startPos = transform.position;
    }

    IEnumerator Shake()
    {
        for (int i = 0; i < 3; i++)
        {
            transform.position = new Vector3(startPos.x + Random.Range(-0.1f, 0.1f), startPos.y + Random.Range(-0.1f, 0.1f), transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }
        transform.position = startPos;
    }

    public void ShakeMe()
    {
        StartCoroutine(Shake());
    }

}