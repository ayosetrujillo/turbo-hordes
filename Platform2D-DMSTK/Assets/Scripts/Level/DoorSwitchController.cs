using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitchController : MonoBehaviour
{
    [SerializeField] private GameObject _switch;
    [SerializeField] private GameObject _door;
    [SerializeField] private AudioClip _sndDoor;
    [SerializeField] private AudioClip _sndSwitch;
    [SerializeField] private GameManager _gameManager;

    private Animator _switchAnimator;
    private Animator _doorAnimator;
    private AudioSource _audioSourceDoor;
    private AudioSource _audioSourceSwitch;

    public bool isOpen = false;
        
    void Awake()
    {
        _switchAnimator = _switch.GetComponent<Animator>();
        _doorAnimator   = _door.GetComponent<Animator>();
        _audioSourceDoor = _door.GetComponent<AudioSource>();
        _audioSourceSwitch = _door.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_gameManager.doorAUnlock == true)
        {
            isOpen = true;
            _switchAnimator.SetBool("Open", true);
            _doorAnimator.SetBool("Open", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isOpen == false)
        {
            if (Input.GetKey(KeyCode.E) || (Input.GetButton("Fire1")))
            {
                if (collision.CompareTag("Player"))
                {
                    isOpen = true;
                    _gameManager.doorAUnlock = true;
                    _audioSourceDoor.PlayOneShot(_sndDoor);
                    //_audioSourceSwitch.PlayOneShot(_sndSwitch);

                    _switchAnimator.SetBool("Open", true);
                    _doorAnimator.SetBool("Open", true);
                    CinemachineShake.Instance.ShakeCamera(0.5f, 0.5f);
                }
            }


        }
        
    }
}
