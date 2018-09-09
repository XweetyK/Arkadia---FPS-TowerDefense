using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamager : MonoBehaviour {

	[SerializeField] private LayerMask _layer;
	[SerializeField] private int damage;

	void OnCollisionEnter(Collision enemy){
		if ((1 << enemy.gameObject.layer) == (int)_layer) {
			enemy.gameObject.GetComponent<Life> ().Damager (damage);
			Destroy (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
}

