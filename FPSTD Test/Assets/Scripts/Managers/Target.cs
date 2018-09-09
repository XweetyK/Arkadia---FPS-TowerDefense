using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	void OnTriggerEnter(Collider enemy){
		enemy.GetComponent<EnemyWalker> ().Destroyer ();
	}
}
