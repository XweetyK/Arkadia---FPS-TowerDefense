using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {

	void Update(){
		recoil *= Mathf.Min(50 * Time.deltaTime, 0.5f);
	}

	public override void shoot(){
		_recoil += _recoilAdd;
		if (_recoil > _maxRecoil) {
			_recoil = _maxRecoil;
		}
		Vector3 origin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0.0f));
		RaycastHit hit;
			if (Physics.Raycast(origin,Camera.main.transform.forward,out hit,_range)){
			if (hit.collider.gameObject.tag == "Enemy")
			{
				hit.collider.GetComponent<Life> ().Damager (_damage);
			}
		}
		Vector3 forward = transform.TransformDirection(Vector3.forward) * _range;
		Debug.DrawRay(origin, forward, Color.green);
	}
}

