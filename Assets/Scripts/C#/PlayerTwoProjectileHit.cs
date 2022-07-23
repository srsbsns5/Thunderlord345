using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerTwoProjectileHit : MonoBehaviour {
	public AudioClip explodeClip;
	public UnityEngine.GameObject explodePrefab;
	private UnityEngine.GameObject controller;
	private PlayerTwoHealth script;

	void Start() {
        controller = UnityEngine.GameObject.Find("Game Controller");
		script = controller.transform.gameObject.GetComponent<PlayerTwoHealth>();
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Bullet 1") {
			Instantiate(explodePrefab, transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint(explodeClip, transform.position);
			script.health -= 25;
			Destroy(collision.gameObject); // Destroy bullet
		}
	}
}