using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMov : MonoBehaviour {

	[SerializeField] private float _range=2;
	[SerializeField] private float _maxDistance;
	[SerializeField] private float _updateRot;
	private GameObject[] _totalEnemies;
	private GameObject _nearest;
	private Transform _target;
	private float _distance;
	private Vector3 _direction;
	private Vector3 _rotation;
	private WallClass _wall;

	void Start(){
		InvokeRepeating ("TargetCheck",0.0f,_updateRot);
		_wall = gameObject.GetComponentInParent<WallClass>();
	}
	void Update(){
		if (_target == null) {
			_wall.Active =false;
			return;
		}
		RotationUpdate ();
		_wall.Active =true;
	}
	void RotationUpdate(){
		_direction = _target.position - transform.position;
		_rotation = (Quaternion.LookRotation (_direction)).eulerAngles;
		transform.rotation = Quaternion.Euler (_rotation.x, _rotation.y, 0.0f);
	}
	void TargetCheck(){
		_maxDistance = Mathf.Infinity;
		_nearest = null;
		_totalEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < _totalEnemies.Length; i++) {
			_distance = Vector3.Distance (transform.position, _totalEnemies [i].transform.position);
			if (_distance < _maxDistance) {
				_maxDistance = _distance;
				_nearest = _totalEnemies [i];
			}
		}
		if (_nearest != null && _maxDistance <= _range) {
			_target = _nearest.transform;
		} else {
			_target = null;
		}

	}
	void OnDrawGizmos(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (transform.position, _range);
	}
}
