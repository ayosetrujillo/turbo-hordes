using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] private int _health = 1;
	[SerializeField] private GameObject burstParticles;
	[SerializeField] private GameObject explosionFX;

	public GameObject _weapon;

	private SpriteRenderer _renderer;

	private void Awake()
	{
		_renderer = GetComponentInChildren<SpriteRenderer>();
	}


	public void AddDamage(int amount)
    {
		_health = _health - amount;

		if (_health <= 0)
        {
			_renderer.enabled = false;
			_weapon.SetActive(false);

			explosionFX.SetActive(true);
			burstParticles.SetActive(true);
			CinemachineShake.Instance.ShakeCamera(1f, 1f);

			StartCoroutine("SetInactive");

		} else {

			StartCoroutine("Damage");

		}

	}



	private IEnumerator SetInactive()
    {
		Debug.Log("DESCONECTÉ");
		yield return new WaitForSeconds(0.5f);
		gameObject.SetActive(false);
	}

	private IEnumerator Damage()
	{
		burstParticles.SetActive(true);
		CinemachineShake.Instance.ShakeCamera(1f, 1f);
		yield return new WaitForSeconds(0.3f);
		burstParticles.SetActive(false);
	}

	private void OnEnable()
    {
		_renderer.enabled = true;
		_weapon.SetActive(true);
		burstParticles.SetActive(false);
		explosionFX.SetActive(false);
	}

}



