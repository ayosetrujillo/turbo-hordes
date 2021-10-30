using UnityEngine;

public class DoorWithSwitchAudioController : MonoBehaviour
{

    [SerializeField] private AudioClip _soundDoorClose;
    [SerializeField] private AudioClip _soundDoorOpen;
    [SerializeField] private AudioClip _soundSwitch;

    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    //Animations Event
    public void PlayAudioAttack1() => _audioSource.PlayOneShot(_soundDoorClose, 1f);
    public void PlayAudioAttack2() => _audioSource.PlayOneShot(_soundDoorOpen, 1f);
    public void PlayAudioAttack3() => _audioSource.PlayOneShot(_soundSwitch, 1f);
}
