using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : MonoBehaviour {
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private float _delay;
	[SerializeField] private LayerMask _layer;
	[Tooltip("Try to use the same as 'Range' in TurretMov")]
	[SerializeField] private float _shootRange;
	private GameObject _bullet;
	private bool _active;
	private WallClass _wall;

	void Start(){
		_wall = gameObject.GetComponentInParent<WallClass>();
		_active = false;
	}
	void Update(){
		if (_wall.Placed == true) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, _shootRange, _layer)) {
				if (!_active) {
					Shoot ();
					_active = true;
				}
			} else {
				_active = false;
			}
		}
	}
	private void Shoot(){
		_bullet = Instantiate (_bulletPrefab);
		_bullet.transform.position = this.transform.position;
		_bullet.transform.rotation = this.transform.rotation;
		if (_wall.Active) {
			Invoke ("Shoot", _delay);
		}
	}
	void OnDrawGizmos(){
		Gizmos.DrawRay(transform.position, transform.forward*_shootRange);
	}
}
