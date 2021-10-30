using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject player;
    public bool active = true;

    public AudioClip audioSpawn;
    private AudioSource _audioSource;

    private Animator _animator;

    public void Awake()
    {
        player.SetActive(false);
        player.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        _animator = player.GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Invoke("Spawn", 0.5f);
    }

    public void Spawn()
    {
        player.SetActive(true);
        _animator.SetTrigger("Spawn");
        _audioSource.PlayOneShot(audioSpawn);
    }


}
