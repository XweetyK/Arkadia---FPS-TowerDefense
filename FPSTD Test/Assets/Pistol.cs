using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {

	void Awake () {
	}

	public override void shoot(){
		Debug.Log ("SHOOT");
		Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0.0f));
		RaycastHit hit;
			if (Physics.Raycast(origin,Camera.main.transform.forward,out hit,_range)){
			Debug.Log (hit.collider.name);
			Debug.Log("HIT");
			if (hit.collider.gameObject.tag == "Enemy")
			{
				hit.collider.GetComponent<Life> ().Damager (_damage);
			}
		}
		Vector3 forward = transform.TransformDirection(Vector3.forward) * _range;
		Debug.DrawRay(origin, forward, Color.green);
	}
}

