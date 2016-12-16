using UnityEngine;
using System.Collections;

public class CollisionEffects : MonoBehaviour {
	public GameObject explosion;
	private float timeToExplode;
	public float explosionTime;
	private bool startExplosion = false;
	// Use this for initialization
	void Start () {
		timeToExplode = explosionTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToExplode >= 0 && startExplosion) {
			timeToExplode -= Time.deltaTime;
		} else {
			timeToExplode = explosionTime;
			startExplosion = false;
			explosion.SetActive (false);
		}
			
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			if (!startExplosion) {
				startExplosion = true;
				explosion.SetActive (true);
			}
		}

	}
}
