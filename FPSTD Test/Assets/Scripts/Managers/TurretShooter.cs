using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : MonoBehaviour {
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private float _fireRate = 1.0f;
	[SerializeField] private LayerMask _layer;
	[Tooltip("Try to use the same as 'Range' in TurretMov")]
	[SerializeField] private float _shootRange;
	private GameObject _bullet;
	private WallClass _wall;
	private float nextFire = 0.0f;

	void Start(){
		_wall = gameObject.GetComponentInParent<WallClass>();
	}
	void Update(){
		if (_wall.Placed == true) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, _shootRange, _layer) && Time.time > nextFire){
					Shoot ();
					nextFire = Time.time + _fireRate;
			}
		}
	}
	private void Shoot(){
		_bullet = Instantiate (_bulletPrefab);
		_bullet.transform.position = this.transform.position;
		_bullet.transform.rotation = this.transform.rotation;
	}
	void OnDrawGizmos(){
		Gizmos.DrawRay(transform.position, transform.forward*_shootRange);
	}
}
