using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Key UI Setting")]
    public float keySpriteWidth = 10f;
    public float keySpriteHeight = 3f;
    public RectTransform actualKeyUI;

    [SerializeField] private int _actualKey = 0;

    void Start()
    {
        actualKeyUI.sizeDelta = new Vector2(keySpriteWidth * _actualKey, keySpriteHeight);
    }

    public void GetKey()
    {
        _actualKey = _actualKey + 1;
        actualKeyUI.sizeDelta = new Vector2(keySpriteWidth * _actualKey, keySpriteHeight);
    }

    public void UseKey()
    {
        if(_actualKey >= 1) {
            _actualKey = _actualKey - 1;
            actualKeyUI.sizeDelta = new Vector2(keySpriteWidth * _actualKey, keySpriteHeight);
        }
    }
}
