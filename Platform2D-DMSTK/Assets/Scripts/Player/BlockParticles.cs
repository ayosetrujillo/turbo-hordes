using UnityEngine;

public class BlockParticles : MonoBehaviour
{

	[Header("Settings Step Particles")]

	public GameObject prefabParticle;
	public Transform pointParticle;
	public Transform pointParticle2;
    public LayerMask playerLayer;
	public float livingTimeParticle;
    public float radioTarget = 2;

    private GameObject instantiateParticle;
    private GameObject instantiateParticle2;
    private bool playerIn = false;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool playerContact = Physics2D.OverlapCircle(transform.position, radioTarget, playerLayer);

        if(playerContact == true)
        {
            playerIn = true;
        } else {
            playerIn = false;
        }
    }

    public void BlockParticlesBottom()
    {
        if (playerIn == true)
        {
            CinemachineShake.Instance.ShakeCamera(1f, 1f);
        }
        

        instantiateParticle = Instantiate(prefabParticle, pointParticle.position, Quaternion.identity);

        instantiateParticle2 = Instantiate(prefabParticle, pointParticle2.position, Quaternion.identity);
        float localScaleX = instantiateParticle2.transform.localScale.x;
        localScaleX = localScaleX * -1f;

        instantiateParticle2.transform.localScale = new Vector3(localScaleX, instantiateParticle2.transform.localScale.y, instantiateParticle2.transform.localScale.z);



        if (livingTimeParticle > 0f)
        {
			Destroy(instantiateParticle, livingTimeParticle);
			Destroy(instantiateParticle2, livingTimeParticle);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioTarget);
    }

}
