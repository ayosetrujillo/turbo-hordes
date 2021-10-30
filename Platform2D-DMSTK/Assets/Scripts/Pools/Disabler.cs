using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("HE ENCONTRADO UN BICHO");
        if (collision.CompareTag("Enemy")) {
            collision.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
