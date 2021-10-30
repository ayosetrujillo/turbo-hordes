using UnityEngine;

public class EnemyAudioController : MonoBehaviour
{

    [SerializeField] private AudioClip _soundAttack1;
    [SerializeField] private AudioClip _soundAttack2;
    [SerializeField] private AudioClip _soundAttack3;

    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    //Animations Event
    public void PlayAudioAttack1() => _audioSource.PlayOneShot(_soundAttack1, 1f);
    public void PlayAudioAttack2() => _audioSource.PlayOneShot(_soundAttack2, 1f);
    public void PlayAudioAttack3() => _audioSource.PlayOneShot(_soundAttack3, 1f);
}
