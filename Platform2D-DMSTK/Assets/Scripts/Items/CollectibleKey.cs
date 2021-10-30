using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectibleKey : MonoBehaviour
{

	[SerializeField] GameObject lightingParticles;
	[SerializeField] GameObject burstParticles;

	
	private SpriteRenderer _renderer;
	private Collider2D _collider;



	private void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_collider = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")) {

			collision.SendMessageUpwards("GetKey");

			Debug.Log("---- He cogido una llave ----");

			_collider.enabled = false;

			//Visual stuff
			_renderer.enabled = false;
			lightingParticles.SetActive(false);
			burstParticles.SetActive(true);
			

			Destroy(gameObject, 2f); 
		}
	}
}
