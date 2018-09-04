using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamager : MonoBehaviour {

	[SerializeField] private LayerMask _layer;
	[SerializeField] private int damage;

	void OnTriggerEnter(Collider enemy){
		Debug.Log ("layer: " + (1 << enemy.gameObject.layer));
		Debug.Log ("_layer: " + (int)_layer);


		if ((1 << enemy.gameObject.layer) == (int)_layer) {
			enemy.gameObject.GetComponent<Life> ().Damager (damage);
			Debug.Log ("yip");
			Destroy (gameObject);
		}
	}
}

