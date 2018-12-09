using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour {

	[SerializeField] Transform _player;
	[SerializeField] float _vel;
	Vector3 _target;

	void Update () {
		_target = new Vector3 (_player.position.x, transform.position.y, transform.position.z);
		transform.position = Vector3.MoveTowards (transform.position, _target, _vel * Time.deltaTime);
	}
}
