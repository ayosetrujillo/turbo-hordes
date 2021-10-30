using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void OnDestroy()
    {

        //gameManager.PreviousLevel = gameObject.scene.name;
    }

}
