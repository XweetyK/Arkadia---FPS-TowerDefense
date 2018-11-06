﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	private LineRenderer _lineR;
	private RaycastHit _hit;
	private Gun _weapon;
	private float _range;
	void Awake () {
		_lineR = GetComponent<LineRenderer> ();
		_weapon = GetComponent<Gun> ();
		_range = _weapon.range;
	}

	void Update () {
		_lineR.SetPosition (0, _weapon.transform.position);
		if (Physics.Raycast (_weapon.transform.position, Camera.main.transform.forward, out _hit, _range)) {
			_lineR.SetPosition (1, _hit.point);
			//Debug.Log (_hit.collider.name);
			Debug.Log (_weapon.transform.position + _weapon.name);
			//Debug.Log (_hit.collider.transform.position);
		} else {
			_lineR.SetPosition (1, _weapon.transform.localPosition);
		}
	}
}
