using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

	[SerializeField] private float vel;
	[SerializeField] private float destroyTime;
	void Awake(){
		Destroy (gameObject, destroyTime);
	}
	void Update () {
		transform.Translate (0.0f, 0.0f, vel * Time.deltaTime);
	}
}
