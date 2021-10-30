using UnityEngine;

public class BlockParticlesMuted : MonoBehaviour
{

	[Header("Settings Block Particles")]

	public GameObject prefabParticle;
	public Transform pointParticle;
	public Transform pointParticle2;
	public float livingTimeParticle;

    private GameObject instantiateParticle;
    private GameObject instantiateParticle2;

    public void BlockParticlesBottom()
    {

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

}
