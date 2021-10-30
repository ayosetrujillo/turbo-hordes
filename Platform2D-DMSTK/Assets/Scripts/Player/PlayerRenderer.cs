using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{

	[Header("Settings Step Particles")]

	public GameObject prefabParticle;
	public Transform pointParticle;
	public float livingTimeParticle;

    private GameObject instantiateParticle;
    private PlayerController _playerController;

    private void Awake()
    {
		_playerController = GetComponent<PlayerController>();
    }


    public void StepParticles()
    {

        if (_playerController.FacingRight) {

            instantiateParticle  = Instantiate(prefabParticle, pointParticle.position, Quaternion.identity);

        } else
        {
            instantiateParticle = Instantiate(prefabParticle, pointParticle.position, Quaternion.identity);

            float localScaleX = instantiateParticle.transform.localScale.x;
            localScaleX = localScaleX * -1f;

            instantiateParticle.transform.localScale = new Vector3(localScaleX, instantiateParticle.transform.localScale.y, instantiateParticle.transform.localScale.z);

        }
	
		if (livingTimeParticle > 0f)
        {
			Destroy(instantiateParticle, livingTimeParticle);
        }

    }

}
