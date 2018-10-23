using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {

	void Awake () {
		_fireRate = 0.2f;
		_damage = 5f;
		_piercing = 2f;
		_magSize = 13;
		_name = "Pistol";
	}

	public override void shoot(){
		Debug.Log ("SHOOT");
		Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0.0f));
		RaycastHit hit;
		Physics.Raycast (origin, Camera.main.transform.forward, out hit, _range);{
			if ((hit.collider.gameObject.layer) == 10) {
				hit.collider.gameObject.GetComponent<Life> ().Damager(_damage);
				Debug.Log ("SHOOT DONE");
			}
		}
	}
}

